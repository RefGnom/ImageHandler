namespace ImageHandler;

internal class ChannelShuffleFilter : PixelFilter
{
    public ChannelShuffleFilter() : base(new ChannelShuffleParameters()) { }

    public override Pixel ProcessPixel(Pixel original, IParameters parameters)
    {
        var shift = (parameters as ChannelShuffleParameters)!.Shift;
        var percent = (parameters as ChannelShuffleParameters)!.Percent;

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