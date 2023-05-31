namespace ImageHandler;

internal class ParameterInfo
{
    public string Name { get; init; }
    public double DefaultValue { get; init; }
    public double MinValue { get; init; }
    public double MaxValue { get; init; }
    public double Increment { get; init; }

    public ParameterInfo(string name, double defaultValue, double minValue, double maxValue, double increment)
    {
        Name = name;
        DefaultValue = defaultValue;
        MinValue = minValue;
        MaxValue = maxValue;
        Increment = increment;
    }
}