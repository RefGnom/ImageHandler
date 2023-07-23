namespace ImageHandler;

internal class PhotoFilter<TParameters> : ParameterizedFilter<TParameters>
    where TParameters : IParameters, new()
{
    private readonly Func<Photo, TParameters, Photo> processor;

    public PhotoFilter(string name, Func<Photo, TParameters, Photo> processor) : base(name)
    {
        this.processor = processor;
    }

    public override Photo Procces(Photo original, TParameters parameters)
    {
        return processor(original, parameters);
    }
}