namespace ImageHandler;

internal class LighteningFilter : PixelFilter
{
    public override ParameterInfo[] GetParameters()
    {
        return new[]
        {
            new ParameterInfo("Коэффициент", 1, 0, 2, 0.05),
        };
    }

    public override Pixel ProcessPixel(Pixel original, double[] parameters)
    {
        return original * parameters[0];
    }

    public override string ToString()
    {
        return "Осветление/затемнение";
    }
}