namespace ImageHandler;

internal class GrayScaleFilter : PixelFilter
{
    public GrayScaleFilter() : base(new GrayScaleParameters()) { }

    public override Pixel ProcessPixel(Pixel original, IParameters parameters)
    {
        var brightness = original.R + original.G + original.B;
        brightness /= 3;
        return new Pixel(original.A, brightness, brightness, brightness) * (parameters as GrayScaleParameters).Brightness;
    }

    public override string ToString()
    {
        return "Сделать чёрно-белым";
    }
}