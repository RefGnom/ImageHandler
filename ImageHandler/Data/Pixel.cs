namespace ImageHandler;

internal struct Pixel
{
    private double a;
    public double A
    {
        get => a;
        set => a = AssertValue(value);
    }

    private double r;
    public double R
    {
        get => r;
        set => r = AssertValue(value);
    }

    private double g;
    public double G
    {
        get => g;
        set => g = AssertValue(value);
    }

    private double b;
    public double B
    {
        get => b;
        set => b = AssertValue(value);
    }

    public Color ToColor()
    {
        return Color.FromArgb(ToChannel(A), ToChannel(R), ToChannel(G), ToChannel(B));
    }

    public static int ToChannel(double value)
    {
        return (int)(value * 255);
    }

    public static Pixel operator *(Pixel pixel, double value)
    {
        return new Pixel()
        {
            A = GetValidValue(pixel.A),
            R = GetValidValue(pixel.R * value),
            G = GetValidValue(pixel.G * value),
            B = GetValidValue(pixel.B * value)
        };
    }

    public static Pixel operator *(double value, Pixel pixel) => pixel * value;

    public static explicit operator Pixel(Color color)
    {
        var pixel = new Pixel();
        pixel.A = (double)color.A / 255;
        pixel.R = (double)color.R / 255;
        pixel.G = (double)color.G / 255;
        pixel.B = (double)color.B / 255;
        return pixel;
    }

    public override string ToString()
    {
        return $"A:{A} R:{R} G:{G} B:{B}";
    }

    private static double GetValidValue(double value)
    {
        if (value < 0 || value > 1)
        {
            value = 1;
            //throw new Exception(string.Format("Wrong color value {0} (the value must be between 0 and 1", value));
        }
        return value;
    }

    private static double AssertValue(double value)
    {
        if (value < 0 || value > 1)
        {
            throw new Exception(string.Format("Wrong color value {0} (the value must be between 0 and 1", value));
        }
        return value;
    }
}