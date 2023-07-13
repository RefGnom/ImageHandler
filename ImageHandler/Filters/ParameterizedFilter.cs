namespace ImageHandler;

internal abstract class ParameterizedFilter : IFilter
{
    private readonly IParameters parameters;

    public ParameterizedFilter(IParameters parameters)
    {
        this.parameters = parameters;
    }

    public ParameterInfo[] GetParameters()
    {
        return parameters.GetDesсription();
    }

    public Photo Process(Photo original, double[] values)
    {
        parameters.Parse(values);
        return Procces(original, parameters);
    }

    public abstract Photo Procces(Photo original, IParameters parameters);
}