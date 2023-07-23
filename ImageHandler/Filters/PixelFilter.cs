namespace ImageHandler;

internal class PixelFilter<TParameters> : ParameterizedFilter<TParameters>
    where TParameters : IParameters, new()
{
    private readonly Func<Pixel, TParameters, Pixel> processor;

    public PixelFilter(string name, Func<Pixel, TParameters, Pixel> processor) : base(name)
    {
        this.processor = processor;
    }

    public override Photo Procces(Photo original, TParameters parameters)
    {
        var result = new Photo(original.Width, original.Height);

        for (int x = 0; x < original.Width; x++)
        {
            for (int y = 0; y < original.Height; y++)
                result[x, y] = processor(original[x, y], parameters);
        }

        return result;
    }
}