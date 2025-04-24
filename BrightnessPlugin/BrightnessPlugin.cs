using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;
using PluginInterface;

[Version(1, 1)]
public class BrightnessPlugin : IPlugin
{
    public string Name => "Повысить яркость";
    public string Author => "Автор";

    public async Task Apply(Bitmap image, IProgress<int> progress, CancellationToken token)
    {
        // Выполним основную работу в фоновом потоке
        await Task.Run(() =>
        {
            // Получаем информацию о пикселях изображения
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            BitmapData bitmapData = image.LockBits(rect, ImageLockMode.ReadWrite, image.PixelFormat);

            int bytesPerPixel = Bitmap.GetPixelFormatSize(image.PixelFormat) / 8;
            int byteCount = bitmapData.Stride * image.Height;
            byte[] pixels = new byte[byteCount];

            // Копируем данные в массив пикселей
            System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);

            int totalPixels = pixels.Length / bytesPerPixel;
            int processedPixels = 0;

            // Проходим по всем пикселям и увеличиваем яркость
            for (int i = 0; i < pixels.Length; i += bytesPerPixel)
            {
                if (token.IsCancellationRequested) break;

                byte b = pixels[i];       // Синий канал
                byte g = pixels[i + 1];   // Зеленый канал
                byte r = pixels[i + 2];   // Красный канал

                // Увеличиваем яркость
                r = (byte)Math.Min(255, r + 40);
                g = (byte)Math.Min(255, g + 40);
                b = (byte)Math.Min(255, b + 40);

                // Применяем обновленные значения
                pixels[i] = b;
                pixels[i + 1] = g;
                pixels[i + 2] = r;

                processedPixels++;
                if (processedPixels % (totalPixels / 100) == 0) 
                {
                    progress?.Report((processedPixels * 100) / totalPixels);
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, bitmapData.Scan0, pixels.Length);

            image.UnlockBits(bitmapData);

            progress?.Report(100);
        });
    }

}
