namespace ImageHandler;

internal abstract class PixelFilter : IFilter
{
    public abstract ParameterInfo[] GetParameters();

    public abstract Pixel ProcessPixel(Pixel original, double[] parameters);

    public Photo Process(Photo original, double[] parameters)
    {
        var result = new Photo(original.Width, original.Height);

        for (int x = 0; x < original.Width; x++)
        {
            for (int y = 0; y < original.Height; y++)
            {
                result[x, y] = ProcessPixel(original[x, y], parameters);
            }
        }

        return result;
    }
}