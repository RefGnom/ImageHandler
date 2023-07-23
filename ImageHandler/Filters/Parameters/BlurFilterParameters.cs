namespace ImageHandler;

internal class BlurFilterParameters : IParameters
{
    public int CoreSize { get; private set; }

    public ParameterInfo[] GetDesсription()
    {
        return new ParameterInfo[]
        {
            new ParameterInfo("Размер ядра", 3, 3, 9, 2, true)
        };
    }

    public void Parse(double[] values)
    {
        CoreSize = (int)values[0];
    }
}