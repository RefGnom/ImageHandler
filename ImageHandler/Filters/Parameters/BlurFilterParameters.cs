namespace ImageHandler;

internal class BlurFilterParameters : FilterParameters
{
    [ParameterInfo("Размер ядра", 3, 3, 9, 2, true)]
    public int CoreSize { get; private set; }

    public override void Parse(double[] values)
    {
        CoreSize = (int)values[0];
    }
}