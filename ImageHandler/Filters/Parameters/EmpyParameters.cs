namespace ImageHandler;

internal class EmpyParameters : IParameters
{
    public ParameterInfo[] GetDesсription()
    {
        return Array.Empty<ParameterInfo>();
    }

    public void Parse(double[] parameters)
    {
    }
}