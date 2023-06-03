namespace ImageHandler;

public interface IFilter
{
    ParameterInfo[] GetParameters();

    Photo Process(Photo original, double[] parameters);
}