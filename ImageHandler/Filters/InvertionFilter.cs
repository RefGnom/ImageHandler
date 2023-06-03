namespace ImageHandler;

internal class InvertionFilter : IFilter
{
    public ParameterInfo[] GetParameters()
    {
        return Array.Empty<ParameterInfo>();
    }

    public Photo Process(Photo original, double[] parameters)
    {
        var result = new Photo(original.Width, original.Height);
        for (int x = 0; x < result.Width; x++)
        {
            for (int y = 0; y < result.Height; y++)
            {
                var p = original[x, y];
                result[x, y] = new Pixel(p.A, 1 - p.R, 1 - p.G, 1 - p.B);
            }
        }
        return result;
    }

    public override string ToString()
    {
        return "Инвертировать цвета";
    }
}