using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalizerGUI.ProjectModule
{
    public interface INewProjectConfigurationCreator
    {
        ProjectConfig CreateConfiguration(string name,string description,string path);
    }
}
