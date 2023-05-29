namespace ImageHandler;

internal class MyForm : Form
{
    private Size windowSize = new(720, 480);
    private readonly SaveFileDialog saveFileDialog = new();
    private readonly OpenFileDialog openFileDialog = new();

    private readonly Label hint = new();
    private readonly PictureBox pictureBox = new();

    public MyForm()
    {
        InitializeComponent();
        InitializeFileDialogs();
        InitializeGUI();
        SizeChanged += (s, e) =>
        {
            var window = s as MyForm;
            windowSize = window!.ClientSize;
        };
    }

    private void InitializeComponent()
    {
        ClientSize = windowSize;
        Name = "Image handler";
    }

    private void InitializeGUI()
    {
        var location = new Point(0, 0);
        var load = new Button()
        {
            Location = location,
            Size = new Size(150, 30),
            Font = new Font("Arial", 14),
            Text = "Load image",
            BackColor = Color.White,
        };
        load.Click += (s, e) =>
        {
            openFileDialog.ShowDialog(this);
        };
        Controls.Add(load);

        location.Y += load.Height;
        var save = new Button()
        {
            Location = location,
            Size = load.Size,
            Font = load.Font,
            Text = "Save image",
            BackColor = load.BackColor,
        };
        save.Click += (s, e) =>
        {
            saveFileDialog.ShowDialog(this);
        };
        Controls.Add(save);

        hint.Location = new Point(load.Width * 2, 0);
        hint.Size = save.Size + new Size(300, 0);
        hint.Font = save.Font;
        Controls.Add(hint);

        pictureBox.Location = new Point(location.X + load.Width + 10, hint.Height + 10);
        Controls.Add(pictureBox);
    }

    private void InitializeFileDialogs()
    {
        saveFileDialog.Filter = "png|*.png|jpeg|*.jpeg";
        saveFileDialog.FileOk += (s, e) =>
        {
            if (s is not SaveFileDialog fileDialog)
                return;
            if (pictureBox.Image is null)
            {
                hint.Text = "Нечего сохранять!";
                return;
            }
            var fileStream = fileDialog.OpenFile();
            pictureBox.Image.Save(fileStream, pictureBox.Image.RawFormat);
            fileStream.Close();
        };

        openFileDialog.Filter = "png|*.png|jpeg|*.jpeg";
        openFileDialog.FileOk += (s, e) =>
        {
            if (s is not OpenFileDialog fileDialog)
                return;
            var stream = fileDialog.OpenFile();
            var image = Image.FromStream(stream);
            pictureBox.Image = image;
            pictureBox.Size = image.Size;
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
        };
    }
}