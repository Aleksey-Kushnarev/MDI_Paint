using System;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Xml.Linq;
using PluginInterface;

using Newtonsoft.Json.Linq;

[Version(1, 1)]
public class DateGeoPlugin : IPlugin
{
    public static string GetGeoLocation()
    {
        try
        {
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString("http://ip-api.com/json/");
                var obj = JObject.Parse(json);
                string city = obj["city"]?.ToString();
                string country = obj["country"]?.ToString();

                if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(country))
                    return $"{city}, {country}";

                return "Данные не найдены";
            }
        }
        catch (Exception ex)
        {
            return "Ошибка: " + ex.Message;
        }
    }

    public string Name => "Добавить дату и геолокацию";
    public string Author => "Автор";
    public void Apply(Bitmap image)
    {
        using (Graphics g = Graphics.FromImage(image))
        {
            string date = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
            string location = "Геолокация: " + GetGeoLocation(); // тут можно подставить реальные данные, если будут

            string text = $"{date} | {location}";
            Font font = new Font("Arial", 16);
            Brush brush = new SolidBrush(Color.White);
            SizeF textSize = g.MeasureString(text, font);
            float x = Math.Max(0, image.Width - textSize.Width - image.Width * 0.1f);
            float y = Math.Max(0, image.Height - textSize.Height - image.Height * 0.1f);
            PointF locationPoint = new PointF(x, y);
            g.DrawString(text, font, brush, locationPoint);
        }
    }
}