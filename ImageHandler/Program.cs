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
        Application.Run(window);
    }
}