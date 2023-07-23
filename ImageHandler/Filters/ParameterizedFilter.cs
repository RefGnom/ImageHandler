namespace ImageHandler;

internal abstract class ParameterizedFilter<T> : IFilter
    where T : IParameters, new()
{
    private readonly string name;
    private readonly T parameters;

    public ParameterizedFilter(string name)
    {
        this.name = name;
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

    public override string ToString()
    {
        return name;
    }

    public abstract Photo Procces(Photo original, T parameters);
}