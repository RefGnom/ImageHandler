using System.Reflection;

namespace ImageHandler;

internal class FilterParameters : IParameters
{
    public ParameterInfo[] GetDesсription()
    {
        var properties = GetType().GetProperties();
        var info = new List<ParameterInfo>();
        for (int i = 0; i < properties.Length; i++)
        {
            var parameterInfo = properties[i].GetCustomAttribute<ParameterInfo>();
            if (parameterInfo is not null)
                info.Add(parameterInfo);
        }
        return info.ToArray();
    }

    public virtual void Parse(double[] values)
    {
        var properties = GetType().GetProperties();
        for (int i = 0; i < values.Length; i++)
        {
            properties[i].SetValue(this, values[i]);
        }
    }
}