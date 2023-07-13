namespace ImageHandler;

internal class ChannelShuffleFilter : PixelFilter
{
    public override ParameterInfo[] GetParameters()
    {
        return new ParameterInfo[]
        {
            new ParameterInfo("Смещение", 0, 0, 3, 0.1)
        };
    }

    public override Pixel ProcessPixel(Pixel original, double[] parameters)
    {
        var shift = (int)parameters[0];
        var percent = parameters[0] - shift;
        var pixel = new Pixel();
        pixel.A = original.A;

        for (int c = 0; c < 3; c++)
        {
            pixel[c] = original[(c + shift) % 3] * (1 - percent);
            pixel[c] += original[(c + shift + 1) % 3] * percent;
        }

        return pixel;
    }

    public override string ToString()
    {
        return "Перемешивание каналов";
    }
}