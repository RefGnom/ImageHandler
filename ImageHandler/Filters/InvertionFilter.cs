namespace ImageHandler;

internal class InvertionFilter : PixelFilter<EmpyParameters>
{
    public override Pixel ProcessPixel(Pixel original, EmpyParameters parameters)
    {
        return new Pixel(original.A, 1 - original.R, 1 - original.G, 1 - original.B);
    }

    public override string ToString()
    {
        return "Инвертировать цвета";
    }
}