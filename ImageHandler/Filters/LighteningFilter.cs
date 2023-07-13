namespace ImageHandler;

internal class LighteningFilter : PixelFilter
{
    public LighteningFilter() : base(new LighteningParameters()) { }

    public override Pixel ProcessPixel(Pixel original, IParameters parameters)
    {
        return original * (parameters as LighteningParameters)!.Coefficient;
    }

    public override string ToString()
    {
        return "Осветление/затемнение";
    }
}