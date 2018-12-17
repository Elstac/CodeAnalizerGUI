using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.ProjectModule;
namespace CodeAnalizerGUI.Interfaces
{
    public interface IProjectInitializer
    {
        void Initialize(string name,string description,string directory);
    }
}
