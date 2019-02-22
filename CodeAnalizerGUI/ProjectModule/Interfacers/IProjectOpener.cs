using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Classes;

namespace CodeAnalizerGUI.ProjectModule
{
    interface IProjectOpener
    {
        void OpenProject(string path);
    }
}
