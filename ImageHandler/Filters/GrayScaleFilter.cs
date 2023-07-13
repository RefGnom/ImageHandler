namespace ImageHandler;

internal class GrayScaleFilter : PixelFilter
{
    public override ParameterInfo[] GetParameters()
    {
        return new[]
        {
            new ParameterInfo("Яркость", 1, 0, 2, 0.05),
        };
    }

    public override Pixel ProcessPixel(Pixel original, double[] parameters)
    {
        var brightness = original.R + original.G + original.B;
        brightness /= 3;
        return new Pixel(original.A, brightness, brightness, brightness) * parameters[0];
    }

    public override string ToString()
    {
        return "Сделать чёрно-белым";
    }
}