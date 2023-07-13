namespace ImageHandler;

internal class InvertionFilter : PixelFilter
{
    public InvertionFilter() : base(new EmpyParameters())
    {
    }

    public override Pixel ProcessPixel(Pixel original, IParameters parameters)
    {
        return new Pixel(original.A, 1 - original.R, 1 - original.G, 1 - original.B);
    }

    public override string ToString()
    {
        return "Инвертировать цвета";
    }
}