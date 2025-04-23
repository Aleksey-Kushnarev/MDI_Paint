using System;
using System.Drawing;
using PluginInterface;
using System.Reflection;

[Version(1, 1)]
public class SobelFilter : IPlugin
{
    public string Name => "Фильтр Собеля";
    public string Author => "Автор";
    public void Apply(Bitmap image)
    {
        // Здесь — простая реализация фильтра Собеля по яркости.
        Bitmap copy = (Bitmap)image.Clone();
        int[,] gx = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
        int[,] gy = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };

        for (int y = 1; y < image.Height - 1; y++)
        {
            for (int x = 1; x < image.Width - 1; x++)
            {
                int pixelX = 0;
                int pixelY = 0;

                for (int j = -1; j <= 1; j++)
                    for (int i = -1; i <= 1; i++)
                    {
                        int gray = (int)(copy.GetPixel(x + i, y + j).GetBrightness() * 255);
                        pixelX += gx[j + 1, i + 1] * gray;
                        pixelY += gy[j + 1, i + 1] * gray;
                    }

                int val = Math.Min(255, Math.Max(0, (int)Math.Sqrt(pixelX * pixelX + pixelY * pixelY)));
                image.SetPixel(x, y, Color.FromArgb(val, val, val));
            }
        }
    }
}