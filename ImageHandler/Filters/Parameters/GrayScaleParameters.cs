namespace ImageHandler;

internal class GrayScaleParameters : IParameters
{
    public double Brightness { get; set; }

    public ParameterInfo[] GetDesсription()
    {
        return new[]
        {
            new ParameterInfo("Яркость", 1, 0, 2, 0.05),
        };
    }

    public void Parse(double[] values)
    {
        Brightness = values[0];
    }
}