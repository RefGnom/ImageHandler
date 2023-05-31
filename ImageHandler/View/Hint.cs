namespace ImageHandler;

internal class Hint : Label
{
    private readonly int maxTime = 4000;
    private int currentTime;

    public Hint()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        Application.Idle += Idle;
        ForeColor = Color.Red;
    }

    public void Show(string text)
    {
        Text = text;
        Show();
        currentTime = maxTime;
    }

    private void Idle(object? sender, EventArgs e)
    {
        if (currentTime < 0)
        {
            Hide();
            return;
        }
        currentTime--;
        Invalidate();
    }
}