using System.Collections;
using System.Drawing.Imaging;

namespace ImageHandler;

public class MyForm : Form, IEnumerable<IFilter>
{
    private readonly Size ButtonSize = new(150, 30);
    private readonly Size ImageMaxSize = new(1200, 400);
    private readonly int indent = 5;

    private readonly SaveFileDialog saveFileDialog = new();
    private readonly OpenFileDialog openFileDialog = new();

    private ComboBox filtersSelect;
    private Panel parametersPanel;
    private List<NumericUpDown> parametersControls;
    private Button apply;
    private Button load;
    private Button save;

    private PictureBox original;
    private PictureBox processed;
    private Bitmap originalBmp;
    private Photo originalPhoto;

    public MyForm()
    {
        InitializeComponent();
        InitializeFileDialogs();
        InitializeGUI();
        SizeChanged += (s, e) => ChangePositionGUI();
    }

    public void Add(IFilter filter)
    {
        filtersSelect.Items.Add(filter);
        if (filtersSelect.SelectedIndex == -1)
            filtersSelect.SelectedIndex = 0;
    }

    private void InitializeComponent()
    {
        Text = "Обработчик изображений";
        ClientSize = new Size(1080, 720);
        ResumeLayout(false);
    }

    private void InitializeGUI()
    {
        var location = new Point(indent, ClientSize.Height - ButtonSize.Height - indent);
        save = new Button()
        {
            Location = location,
            Size = ButtonSize,
            Font = new Font("Arial", 14),
            Text = "Сохранить",
            Enabled = false,
        };
        save.Click += (s, e) => saveFileDialog.ShowDialog(this);
        Controls.Add(save);

        location.Y -= ButtonSize.Height;
        load = new Button()
        {
            Location = location,
            Size = ButtonSize,
            Font = save.Font,
            Text = "Загрузить",
        };
        load.Click += (s, e) =>
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                apply.Enabled = true;
                processed.Hide();
            }
        };
        Controls.Add(load);

        location.Y -= ButtonSize.Height * 2;
        apply = new Button()
        {
            Location = location,
            Size = ButtonSize,
            Font = save.Font,
            Text = "Применить",
            Enabled = false,
        };
        apply.Click += Process;
        Controls.Add(apply);

        filtersSelect = new ComboBox()
        {
            DropDownStyle = ComboBoxStyle.DropDownList,
            Location = new Point(indent, indent),
            Size = ButtonSize,
        };
        filtersSelect.SelectedIndexChanged += FilterChanged;
        Controls.Add(filtersSelect);

        original = new PictureBox();
        original.BorderStyle = BorderStyle.FixedSingle;
        original.Hide();
        Controls.Add(original);

        processed = new PictureBox();
        processed.BorderStyle = BorderStyle.FixedSingle;
        processed.Hide();
        Controls.Add(processed);
    }

    private void ChangePositionGUI()
    {
        if (originalBmp is not null)
        {
            original.Image = originalBmp;
            original.Location = new Point(filtersSelect.Right + indent, indent);
            original.ClientSize = originalBmp.Size;

            processed.Location = new Point(filtersSelect.Right + indent, original.Bottom + indent);
            processed.Size = original.Size;
        }

        if (original.Right + indent > ClientSize.Width)
            ClientSize = new Size(original.Right + indent, ClientSize.Height);
        if (processed.Bottom + indent > ClientSize.Height)
            ClientSize = new Size(ClientSize.Width, processed.Bottom + indent);

        var location = new Point(indent, ClientSize.Height - ButtonSize.Height - indent);
        save.Location = location;

        location.Y -= ButtonSize.Height;
        load.Location = location;

        location.Y -= ButtonSize.Height * 2;
        apply.Location = location;
    }

    private void InitializeFileDialogs()
    {
        saveFileDialog.Filter = "png|*.png";
        saveFileDialog.FileOk += (s, e) =>
        {
            if (s is not SaveFileDialog fileDialog)
                return;
            var fileStream = fileDialog.OpenFile();
            processed.Image.Save(fileStream, ImageFormat.Png);
            fileStream.Close();
        };

        openFileDialog.Filter = "png|*.png";
        openFileDialog.FileOk += (s, e) =>
        {
            if (s is not OpenFileDialog fileDialog)
                return;
            var stream = fileDialog.OpenFile();
            var image = Image.FromStream(stream);
            originalBmp = new Bitmap(image);
            LoadBitmap(originalBmp);
            original.Image = originalBmp;
        };
    }

    private void LoadBitmap(Bitmap bmp)
    {
        if (bmp.Size.Width > ImageMaxSize.Width || bmp.Size.Height > ImageMaxSize.Height)
        {
            var scale = Math.Min((float)ImageMaxSize.Width / bmp.Width, (float)ImageMaxSize.Height / bmp.Height);
            bmp = bmp.ApplyScale(scale);
        }
        originalBmp = bmp;
        originalPhoto = Convertor.Bitmap2Photo(bmp);
        original.Show();

        ChangePositionGUI();

        FilterChanged(null, EventArgs.Empty);
    }

    private void FilterChanged(object? sender, EventArgs e)
    {
        var filter = (IFilter)filtersSelect.SelectedItem;
        if (filter == null) return;
        if (parametersPanel != null)
            Controls.Remove(parametersPanel);

        parametersControls = new List<NumericUpDown>();
        parametersPanel = new Panel();
        parametersPanel.Left = filtersSelect.Left;
        parametersPanel.Top = filtersSelect.Bottom + 10;
        parametersPanel.Width = filtersSelect.Width;
        parametersPanel.Height = ClientSize.Height - parametersPanel.Top - apply.Top;

        int y = 0;

        foreach (var param in filter.GetParameters())
        {
            var label = new Label();
            label.Left = 0;
            label.Top = y;
            label.Width = parametersPanel.Width - 50;
            label.Height = 20;
            label.Text = param.Name;
            parametersPanel.Controls.Add(label);

            var box = new NumericUpDown();
            box.Left = label.Right;
            box.Top = y;
            box.Width = 50;
            box.Height = 20;
            box.Value = (decimal)param.DefaultValue;
            box.Increment = (decimal)param.Increment;
            box.Maximum = (decimal)param.MaxValue;
            box.Minimum = (decimal)param.MinValue;
            box.DecimalPlaces = param.IsInteger ? 0 : 2;
            parametersPanel.Controls.Add(box);
            y += label.Height + 5;
            parametersControls.Add(box);
        }
        Controls.Add(parametersPanel);
    }


    private void Process(object? sender, EventArgs empty)
    {
        var data = parametersControls.Select(z => (double)z.Value).ToArray();
        var filter = (IFilter)filtersSelect.SelectedItem;
        var photo = filter.Process(originalPhoto, data);
        var processedBmp = Convertor.Photo2Bitmap(photo);
        if (processedBmp.Width > originalBmp.Width || processedBmp.Height > originalBmp.Height)
        {
            var scale = Math.Min((float)originalBmp.Width / processedBmp.Width, (float)originalBmp.Height / processedBmp.Height);
            processedBmp = processedBmp.ApplyScale(scale);
        }
        processed.Image = processedBmp;
        processed.Show();
        save.Enabled = true;
    }

    public IEnumerator<IFilter> GetEnumerator()
    {
        foreach (IFilter filter in filtersSelect.Items)
            yield return filter;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}