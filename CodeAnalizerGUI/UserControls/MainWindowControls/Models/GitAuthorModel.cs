using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
namespace CodeAnalizerGUI.UserControls.MainWindowControls.Models
{
    class GitAuthorModel : INotifyPropertyChanged
    {
        private string name;
        private string email;
        private int commitsCount;

        public GitAuthorModel(string name, string email, int commitsCount)
        {
            this.name = name;
            this.email = email;
            this.commitsCount = commitsCount;
        }

        public string Name { get => name; set { name = value; RaisePropertyChanged("Name"); } }
        public string Email { get => email; set { email = value; RaisePropertyChanged("Email"); } }
        public int CommitsCount { get => commitsCount; set { commitsCount = value; RaisePropertyChanged("CommitsCount"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
