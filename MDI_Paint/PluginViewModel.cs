using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDI_Paint
{
    public class PluginViewModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public bool Load { get; set; }

        // Скрытое поле — не показываем в таблице
        [JsonIgnore]
        public string FileName { get; set; }
    }
}
