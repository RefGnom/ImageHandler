namespace ImageHandler;

internal class LighteningParameters : IParameters
{
    public double Coefficient { get; set; }

    public ParameterInfo[] GetDesсription()
    {
        return new[]
        {
            new ParameterInfo("Коэффициент", 1, 0, 10, 0.05),
        };
    }

    public void Parse(double[] values)
    {
        Coefficient = values[0];
    }
}
