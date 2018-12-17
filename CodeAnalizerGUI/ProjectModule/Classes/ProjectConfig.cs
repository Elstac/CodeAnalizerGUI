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
        public string Directory{ get; set; }

        public override bool Equals(object obj)
        {
            var o = obj as ProjectConfig;
            return (Name == o.Name&& Description == o.Description&& Directory == o.Directory);
        }
    }

    
}
