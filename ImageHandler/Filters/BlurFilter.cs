namespace ImageHandler;

internal class BlurFilter : IFilter
{
    public ParameterInfo[] GetParameters()
    {
        return new ParameterInfo[]
        {
            new ParameterInfo("Размер ядра", 3, 3, 9, 2, true)
        };
    }

    public Photo Process(Photo original, double[] parameters)
    {
        var result = new Photo(original.Width, original.Height);
        for (int x = 0; x < result.Width; x++)
        {
            for (int y = 0; y < result.Height; y++)
            {
                result[x, y] = GetMedian(original, x, y, (int)parameters[0]);
            }
        }
        return result;
    }

    private static Pixel GetMedian(Photo photo, int x, int y, int size)
    {
        var pixels = new List<Pixel>();
        for (int i = x - size / 2; i <= x + size / 2; i++)
        {
            for (int j = y - size / 2; j <= y + size / 2; j++)
            {
                if (i > 0 && i < photo.Width && j > 0 && j < photo.Height)
                    pixels.Add(photo[i, j]);
            }
        }
        pixels.Sort((f, s) => (f.R + f.G + f.B).CompareTo((s.R + s.G + s.B)));
        return pixels[pixels.Count / 2];
    }

    public override string ToString()
    {
        return "Размытие";
    }
}