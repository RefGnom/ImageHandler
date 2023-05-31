namespace ImageHandler;

internal struct Pixel
{
    private double r;
    public double R
    {
        get => r;
        set => r = AssertColorValue(value);
    }

    private double g;
    public double G
    {
        get => g;
        set => g = AssertColorValue(value);
    }

    private double b;
    public double B
    {
        get => b;
        set => b = AssertColorValue(value);
    }

    public static Pixel operator *(Pixel pixel, double parameter)
    {
        return new Pixel()
        {
            R = pixel.R * parameter,
            G = pixel.G * parameter,
            B = pixel.B * parameter
        };
    }

    public static explicit operator Pixel(Color color)
    {
        var pixel = new Pixel();
        pixel.R = (double)color.R / 255;
        pixel.G = (double)color.G / 255;
        pixel.B = (double)color.B / 255;
        return pixel;
    }

    private static double AssertColorValue(double value)
    {
        if (value < 0 || value > 1)
            throw new Exception(string.Format("Wrong color value {0} (the value must be between 0 and 1", value));
        return value;
    }
}