using Newtonsoft.Json;
using PluginInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI_Paint
{
    public partial class PluginManagerForm : Form
    {
        public PluginManagerForm(PluginConfig config)
        {
            InitializeComponent();

            var pluginDir = Path.Combine(Application.StartupPath, "Plugins");
            var pluginModels = new List<PluginViewModel>();

            foreach (var entry in config.Plugins)
            {
                string path = Path.Combine(pluginDir, entry.Name);
               

                try
                {
                    var asm = Assembly.LoadFrom(path);
                    var pluginType = asm.GetTypes().FirstOrDefault(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface);
                    if (pluginType == null) continue;

                    var plugin = (IPlugin)Activator.CreateInstance(pluginType);
                    var versionAttr = pluginType.GetCustomAttribute<VersionAttribute>();

                    pluginModels.Add(new PluginViewModel
                    {
                        Name = plugin.Name,
                        Author = plugin.Author,
                        Version = versionAttr.Major.ToString(),
                        Load = entry.Load,
                        FileName = entry.Name // <-- сохраняем имя файла .dll
                    });
                }
                catch (Exception ex) { 
                    MessageBox.Show(ex.Message); }
            }

            dataGridView1.DataSource = new BindingList<PluginViewModel>(pluginModels);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var config = new PluginConfig
            {
                AutoLoad = false,
                Plugins = new List<PluginEntry>()
            };

            foreach (PluginViewModel vm in dataGridView1.DataSource as BindingList<PluginViewModel>)
            {
                config.Plugins.Add(new PluginEntry
                {
                    Name = vm.FileName,
                    Load = vm.Load
                });
            }

            string configPath = Path.Combine(Application.StartupPath, "plugins.config.json");
            File.WriteAllText(configPath, JsonConvert.SerializeObject(config, Formatting.Indented));
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
