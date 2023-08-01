namespace ImageHandler;

internal class LighteningParameters : FilterParameters
{
    [ParameterInfo("Коэффициент", 1, 0, 10, 0.05)]
    public double Coefficient { get; set; }
}