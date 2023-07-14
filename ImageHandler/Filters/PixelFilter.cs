namespace ImageHandler;

internal abstract class PixelFilter<T> : ParameterizedFilter<T>
    where T : IParameters, new()
{
    public abstract Pixel ProcessPixel(Pixel original, T parameters);

    public override Photo Procces(Photo original, T parameters)
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