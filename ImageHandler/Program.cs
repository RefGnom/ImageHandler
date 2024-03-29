namespace ImageHandler;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        var window = new MyForm()
        {
            Filters.LighteningFilter,
            Filters.GrayScaleFilter,
            Filters.InvertionFilter,
            Filters.ChannelShuffleFilter,
            Filters.BlurFilter
        };
        Application.Run(window);
    }
}