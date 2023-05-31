namespace ImageHandler;

internal static class BitmapExtension
{
    public static Bitmap ApplyScale(this Bitmap bmp, float scale)
    {
        var newBmp = new Bitmap((int)(bmp.Width * scale), (int)(bmp.Height * scale));
        var graphics = Graphics.FromImage(newBmp);
        graphics.DrawImage(bmp, new Rectangle(0, 0, newBmp.Width, newBmp.Height), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
        return newBmp;
    }
}