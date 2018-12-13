using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using CodeAnalizerGUI.Abstractions;
namespace CodeAnalizerGUI.Models
{
    public class GitAuthorModel : Model
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

        
    }
}
