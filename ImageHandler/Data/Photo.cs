namespace ImageHandler;

public class Photo
{
    public readonly int Width;
    public readonly int Height;
    private readonly Pixel[,] data;

    public Pixel this[int x, int y]
    {
        get => data[x, y];
        set => data[x, y] = value;
    }

    public Photo(int width, int height)
    {
        Width = width;
        Height = height;
        data = new Pixel[Width, Height];
    }

    public Pixel GetMedian(int x, int y, int size)
    {
        var pixels = new List<Pixel>();
        for (int i = x - size / 2; i <= x + size / 2; i++)
        {
            for (int j = y - size / 2; j <= y + size / 2; j++)
            {
                if (i > 0 && i < Width && j > 0 && j < Height)
                    pixels.Add(data[i, j]);
            }
        }
        pixels.Sort((f, s) => (f.R + f.G + f.B).CompareTo((s.R + s.G + s.B)));
        return pixels[pixels.Count / 2];
    }
}