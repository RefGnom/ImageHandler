namespace ImageHandler;

internal class GrayScaleFilter : PixelFilter<GrayScaleParameters>
{
    public override Pixel ProcessPixel(Pixel original, GrayScaleParameters parameters)
    {
        var brightness = original.R + original.G + original.B;
        brightness /= 3;
        return new Pixel(original.A, brightness, brightness, brightness) * parameters.Brightness;
    }

    public override string ToString()
    {
        return "Сделать чёрно-белым";
    }
}