namespace ImageHandler;

internal static class Convertor
{
    public static Photo Bitmap2Photo(Bitmap bmp)
    {
        var photo = new Photo(bmp.Width, bmp.Height);
        for (int x = 0; x < bmp.Width; x++)
        {
            for (int y = 0; y < bmp.Height; y++)
            {
                var pixel = bmp.GetPixel(x, y);
                photo[x, y] = (Pixel)pixel;
            }
        }
        return photo;
    }

    public static Bitmap Photo2Bitmap(Photo photo)
    {
        var bmp = new Bitmap(photo.Width, photo.Height);
        for (int x = 0; x < bmp.Width; x++)
            for (int y = 0; y < bmp.Height; y++)
                bmp.SetPixel(x, y, (Color)photo[x, y]);

        return bmp;
    }
}