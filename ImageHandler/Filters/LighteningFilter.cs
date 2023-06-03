﻿namespace ImageHandler;

internal class LighteningFilter : IFilter
{
    public ParameterInfo[] GetParameters()
    {
        return new[]
        {
            new ParameterInfo("Коэффициент", 1, 0, 2, 0.05),
        };
    }

    public override string ToString()
    {
        return "Осветление/затемнение";
    }

    public Photo Process(Photo original, double[] parameters)
    {
        var result = new Photo(original.Width, original.Height);
        for (int x = 0; x < result.Width; x++)
        {
            for (int y = 0; y < result.Height; y++)
            {
                result[x, y] = original[x, y] * parameters[0];
            }
        }
        return result;
    }
}