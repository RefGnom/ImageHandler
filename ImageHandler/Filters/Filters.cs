namespace ImageHandler;

internal static class Filters
{
    public static PixelFilter<LighteningParameters> LighteningFilter => new("Осветление/затемнение",
        (original, parameters) => original * parameters.Coefficient);

    public static PixelFilter<GrayScaleParameters> GrayScaleFilter => new("Оттенки серого",
        (original, parameters) =>
        {
            var brightness = original.R + original.G + original.B;
            brightness /= 3;
            return new Pixel(original.A, brightness, brightness, brightness) * parameters.Brightness;
        });

    public static PixelFilter<EmpyParameters> InvertionFilter => new("Инвертирование цветов",
        (original, parameters) => new Pixel(original.A, 1 - original.R, 1 - original.G, 1 - original.B));

    public static PixelFilter<ChannelShuffleParameters> ChannelShuffleFilter => new("Перемешивание каналов",
        (original, parameters) =>
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
        });
}