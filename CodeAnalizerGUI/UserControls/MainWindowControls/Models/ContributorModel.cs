using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace CodeAnalizerGUI.UserControls.MainWindowControls.Models
{
    public class ContributorModel:INotifyPropertyChanged
    {
        private string name="Name";
        private string email="Email";
        private string pathToImage;
        private List<string> pathsToFiles;

        public ContributorModel()
        {
            pathToImage = null;
            pathsToFiles = new List<string>();
        }

        public string Name { get => name; set { Name = value; RaisePropertyChange("Name"); } }
        public string Email { get => email; set { Email = value; RaisePropertyChange("Email"); } }
        public string PathToImage { get => pathToImage; set => pathToImage = value; }
        public List<string> PathsToFiles { get => pathsToFiles; set => pathsToFiles = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        public override bool Equals(object obj)
        {
            ContributorModel tem = obj as ContributorModel;
            return (tem.name == name && tem.pathToImage == pathToImage && tem.email == email);
        }

        private void RaisePropertyChange(string parameter)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(parameter));
        }
    }
}
