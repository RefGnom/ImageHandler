namespace ImageHandler;

internal class ChannelShuffleParameters : IParameters
{
    public int Shift { get; set; }
    public double Percent { get; set; }

    public ParameterInfo[] GetDesсription()
    {
        return new ParameterInfo[]
        {
            new ParameterInfo("Смещение", 0, 0, 3, 0.1)
        };
    }

    public void Parse(double[] values)
    {
        Shift = (int)values[0];
        Percent = values[0] - Shift;
    }
}