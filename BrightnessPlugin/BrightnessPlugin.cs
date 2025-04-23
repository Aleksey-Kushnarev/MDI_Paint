using System;
using System.Drawing;
using PluginInterface;

[Version(1, 1)]
public class BrightnessPlugin : IPlugin
{
    public string Name => "Повысить яркость";
    public string Author => "Автор";
    public void Apply(Bitmap image)
    {
        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                Color oldColor = image.GetPixel(x, y);
                int r = Math.Min(255, oldColor.R + 40);
                int g = Math.Min(255, oldColor.G + 40);
                int b = Math.Min(255, oldColor.B + 40);
                image.SetPixel(x, y, Color.FromArgb(r, g, b));
            }
        }
    }
}