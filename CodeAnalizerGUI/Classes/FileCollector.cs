using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using System.IO;
namespace CodeAnalizerGUI.Classes
{
    public class FileCollector : IFileCollector
    {
        private string pathToRes;

        public FileCollector(string pathToRes)
        {
            this.pathToRes = pathToRes;
        }

        public string MoveToResources(string path)
        {
            int index = path.LastIndexOf('\\')+1;
            string fileName = path.Substring(index);
            index = 0;
            string tmp=fileName;
            while (File.Exists(pathToRes + tmp))
                tmp = fileName.Insert(fileName.LastIndexOf('.'), "(" + ++index + ")");

            File.Copy(path, pathToRes+ tmp);
            return pathToRes + tmp;
        }
    }
}
