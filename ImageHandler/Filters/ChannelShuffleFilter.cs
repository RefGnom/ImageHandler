namespace ImageHandler;

internal class ChannelShuffleFilter : PixelFilter<ChannelShuffleParameters>
{
    public override Pixel ProcessPixel(Pixel original, ChannelShuffleParameters parameters)
    {
        var shift = parameters.Shift;
        var percent = parameters.Percent;

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