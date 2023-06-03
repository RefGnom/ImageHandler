namespace ImageHandler;

internal class ChannelShuffleFilter : IFilter
{
    public ParameterInfo[] GetParameters()
    {
        return new ParameterInfo[]
        {
            new ParameterInfo("Смещение", 0, 0, 3, 0.1)
        };
    }

    public Photo Process(Photo original, double[] parameters)
    {
        var shift = (int)parameters[0];
        var percent = parameters[0] - shift;
        var result = new Photo(original.Width, original.Height);
        for (int x = 0; x < result.Width; x++)
        {
            for (int y = 0; y < result.Height; y++)
            {
                var pixel = new Pixel();
                pixel.A = original[x, y].A;

                for (int c = 0; c < 3; c++)
                {
                    pixel[c] = original[x, y][(c + shift) % 3] * (1 - percent);
                    pixel[c] += original[x, y][(c + shift + 1) % 3] * percent;
                }

                result[x, y] = pixel;
            }
        }
        return result;
    }

    public override string ToString()
    {
        return "Перемешивание каналов";
    }
}