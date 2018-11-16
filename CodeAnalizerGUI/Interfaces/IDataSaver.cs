using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using CodeAnalizerGUI.Abstractions;
namespace CodeAnalizerGUI.Interfaces
{
    public interface IDataSaver
    {
        void AddModel(Model toAdd);
        void DeleteModel(Model toDel);
        Model[] GetModel();
        void SaveData();
    }
}
