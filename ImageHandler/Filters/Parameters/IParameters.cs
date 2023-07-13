namespace ImageHandler;

internal interface IParameters
{
    ParameterInfo[] GetDesсription();

    void Parse(double[] values);
}