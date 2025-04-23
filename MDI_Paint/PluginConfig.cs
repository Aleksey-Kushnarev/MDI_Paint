using Newtonsoft.Json;
using PluginInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI_Paint
{
    public class PluginConfig
    {
        public bool AutoLoad { get; set; } = true;
        public List<PluginEntry> Plugins { get; set; } = new List<PluginEntry>();

        public static PluginConfig LoadOrCreatePluginConfig(string configPath, string pluginDir)
        {
            if (!File.Exists(configPath))
            {
                // Создаем новый конфиг на основе содержимого директории
                var pluginFiles = Directory.GetFiles(pluginDir, "*.dll").Select(Path.GetFileName);
                var config = new PluginConfig
                {
                    AutoLoad = true,
                    Plugins = pluginFiles.Select(f => new PluginEntry { Name = f, Load = true }).ToList()
                };

                File.WriteAllText(configPath, JsonConvert.SerializeObject(config, Formatting.Indented));
                return config;
            }

            // Загружаем существующий
            string json = File.ReadAllText(configPath);
            return JsonConvert.DeserializeObject<PluginConfig>(json);
        }

        public static List<IPlugin> LoadPlugins(string pluginDir, PluginConfig config)
        {
            var plugins = new List<IPlugin>();
            var filesToLoad = config.AutoLoad
                ? Directory.GetFiles(pluginDir, "*.dll")
                : config.Plugins.Where(p => p.Load)
                                .Select(p => Path.Combine(pluginDir, p.Name))
                                .Where(File.Exists);

            foreach (var file in filesToLoad)
            {
                try
                {
                    var assembly = Assembly.LoadFrom(file);
                    var types = assembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface);

                    foreach (var type in types)
                    {
                        var plugin = (IPlugin)Activator.CreateInstance(type);
                        plugins.Add(plugin);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки {file}: {ex.Message}");
                }
            }

            return plugins;
        }
    }


}
