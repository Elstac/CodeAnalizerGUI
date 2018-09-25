using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizer.FileAnalizerModule.Interfaces;
namespace CodeAnalizerGUI.Interfaces
{
    interface ILogicHolder
    {
        IFileMiner GetFileMiner(string[] paths,bool addToProject);
        IFileMiner GetGlobalFileMiner();
    }
}
