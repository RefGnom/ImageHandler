namespace ImageHandler;

internal abstract class PixelFilter : ParameterizedFilter
{
    public PixelFilter(IParameters parameters) : base(parameters) { }

    public abstract Pixel ProcessPixel(Pixel original, IParameters parameters);

    public override Photo Procces(Photo original, IParameters parameters)
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