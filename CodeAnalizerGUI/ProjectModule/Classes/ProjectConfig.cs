using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalizerGUI.ProjectModule
{
    public class ProjectConfig
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Files { get; set; }
    }
}
