namespace ImageHandler;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        var window = new MyForm();
        window.AddFilter(new LighteningFilter());
        window.AddFilter(new MakeInBlackAndWhiteFilter());
        window.AddFilter(new InvertionFilter());
        window.AddFilter(new ChannelShuffleFilter());
        Application.Run(window);
    }
}