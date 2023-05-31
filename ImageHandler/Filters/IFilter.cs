namespace ImageHandler;

internal interface IFilter
{
    ParameterInfo[] GetParameters();

    Photo Process(Photo original, double[] parameters);
}