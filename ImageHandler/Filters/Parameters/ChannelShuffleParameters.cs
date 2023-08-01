namespace ImageHandler;

internal class ChannelShuffleParameters : FilterParameters
{
    [ParameterInfo("Смещение", 0, 0, 3, 0.1)]
    public int Shift { get; private set; }
    public double Percent { get; private set; }

    public override void Parse(double[] values)
    {
        Shift = (int)values[0];
        Percent = values[0] - Shift;
    }
}