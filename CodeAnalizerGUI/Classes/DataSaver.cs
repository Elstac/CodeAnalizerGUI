using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;

namespace CodeAnalizerGUI.Classes
{
    public class DataSaver : Interfaces.IDataSaver
    {
        private List<Model> savedModels;
        private Interfaces.IDataSaver globalSaver;
        public DataSaver(Interfaces.IDataSaver globalSaver)
        {
            savedModels = new List<Model>();
            this.globalSaver = globalSaver;
        }

        public void AddModel(Model toAdd)
        {
            savedModels.Add(toAdd);
        }

        public void DeleteModel(Model toDel)
        {
            savedModels.Remove(toDel);
        }

        public Model[] GetModel()
        {
            return savedModels.ToArray();
        }

        public void SaveData()
        {
            foreach (var item in savedModels)
            {
                globalSaver.AddModel(item);
            }
        }
    }
}
