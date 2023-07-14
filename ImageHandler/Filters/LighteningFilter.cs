namespace ImageHandler;

internal class LighteningFilter : PixelFilter<LighteningParameters>
{
    public override Pixel ProcessPixel(Pixel original, LighteningParameters parameters)
    {
        return original * parameters.Coefficient;
    }

    public override string ToString()
    {
        return "Осветление/затемнение";
    }
}