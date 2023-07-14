namespace ImageHandler;

internal abstract class ParameterizedFilter<T> : IFilter
    where T : IParameters, new()
{
    private readonly T parameters;

    public ParameterizedFilter()
    {
        parameters = new T();
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

    public abstract Photo Procces(Photo original, T parameters);
}