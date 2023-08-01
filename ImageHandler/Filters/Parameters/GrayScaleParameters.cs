namespace ImageHandler;

internal class GrayScaleParameters : FilterParameters
{
    [ParameterInfo("Яркость", 1, 0, 2, 0.05)]
    public double Brightness { get; set; }
}