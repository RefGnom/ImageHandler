namespace ImageHandler;

internal class PhotoFilter<TParameters> : ParameterizedFilter<TParameters>
    where TParameters : IParameters, new()
{
    private readonly string name;
    private readonly Func<Photo, TParameters, Photo> processor;

    public PhotoFilter(string name, Func<Photo, TParameters, Photo> processor)
    {
        this.name = name;
        this.processor = processor;
    }

    public override Photo Procces(Photo original, TParameters parameters)
    {
        return processor(original, parameters);
    }

    public override string ToString()
    {
        return name;
    }
}