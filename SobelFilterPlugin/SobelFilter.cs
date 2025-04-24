using System;
using System.Drawing;
using PluginInterface;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading;

[Version(1, 1)]
public class SobelFilter : IPlugin
{
    public string Name => "Фильтр Собеля";
    public string Author => "Автор";

    public async Task Apply(Bitmap image, IProgress<int> progress, CancellationToken token)
    {
        await Task.Run(() =>
        {
            Bitmap copy = (Bitmap)image.Clone();
            int[,] gx = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] gy = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };

            int totalPixels = (image.Width - 2) * (image.Height - 2);
            int processedPixels = 0;

            for (int y = 1; y < image.Height - 1; y++)
            {
                for (int x = 1; x < image.Width - 1; x++)
                {
                    if (token.IsCancellationRequested)
                        return;

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

                    processedPixels++;
                    progress.Report((int)((float)processedPixels / totalPixels * 100)); // Обновление прогресса
                }
            }
        });
    }

}