using System.Drawing.Imaging;

namespace ImageHandler;

internal class MyForm : Form
{
    private readonly SaveFileDialog saveFileDialog = new();
    private readonly OpenFileDialog openFileDialog = new();

    private readonly Label hint = new();

    private Image? currentImage;

    public MyForm()
    {
        InitializeFileDialogs();
        InitializeComponent();
    }

    private void InitializeFileDialogs()
    {
        saveFileDialog.Filter = "png|*.png|jpeg|*.jpeg";
        saveFileDialog.FileOk += (s, e) =>
        {
            if (s is not SaveFileDialog fileDialog)
                return;
            if (currentImage is null)
            {
                hint.Text = "Нечего сохранять!";
                return;
            }
            var fileStream = fileDialog.OpenFile();
            currentImage.Save(fileStream, ImageFormat.Png);
            fileStream.Close();
        };

        openFileDialog.Filter = "png|*.png|jpeg|*.jpeg";
        openFileDialog.FileOk += (s, e) =>
        {
            if (s is not OpenFileDialog fileDialog)
                return;
            var stream = fileDialog.OpenFile();
            var image = Image.FromStream(stream);
            hint.Text = $"{image.Width} {image.Height}";
            currentImage = image;
        };
    }

    private void InitializeComponent()
    {
        ClientSize = new Size(720, 480);
        Name = "Image handler";

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

        location.Y += save.Height;
        hint.Location = location;
        hint.Size = save.Size + new Size(300, 0);
        hint.Font = save.Font;
        Controls.Add(hint);
    }
}