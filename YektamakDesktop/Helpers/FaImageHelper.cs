using FontAwesome.Sharp;
using System.Drawing;

public static class FaImageHelper
{
    public static Bitmap Create(
        IconChar icon,
        int size = 32,
        Color? color = null)
    {
        var iconPictureBox = new IconPictureBox
        {
            IconChar = icon,
            IconColor = color ?? Color.DarkCyan,
            IconSize = size,
            Size = new Size(size, size)
        };

        var bmp = new Bitmap(size, size);
        iconPictureBox.DrawToBitmap(bmp, new Rectangle(0, 0, size, size));

        return bmp;
    }
}
