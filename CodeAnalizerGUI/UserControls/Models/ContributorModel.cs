using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using CodeAnalizerGUI.Abstractions;
namespace CodeAnalizerGUI.Models
{
    public class ContributorModel: Model
    {
        private string name="Name";
        private string email="Email";
        private string pathToImage= Properties.Settings.Default.AppData + "\\NoFile.png";
        private List<string> pathsToFiles;

        public ContributorModel()
        {
            pathsToFiles = new List<string>();
        }
        
        public string Name { get => name; set { name = value; RaisePropertyChanged("Name"); } }
        public string Email { get => email; set { email = value; RaisePropertyChanged("Email"); } }
        public string PathToImage { get => pathToImage; set { pathToImage = value; RaisePropertyChanged("PathToImage"); } }
        public List<string> PathsToFiles { get => pathsToFiles; set => pathsToFiles = value; }

        public override bool Equals(object obj)
        {
            ContributorModel tem = obj as ContributorModel;
            return (tem.name == name && tem.pathToImage == pathToImage && tem.email == email);
        }

    }
}
