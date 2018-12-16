using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Models;
using CodeAnalizerGUI.Abstractions;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizer.GitTrackerModule.Classes;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;
namespace CodeAnalizerGUI.ViewModels
{
    public class GitBinderViewModel:ViewModel
    {
       
        private GitAuthorModel selectedAuthor;
        private ObservableCollection<GitAuthorModel> authors;
        public ICommand SelectCommand { get; set; }

        public ObservableCollection<GitAuthorModel> Authors { get => authors; set { authors = value;} }
        public GitAuthorModel SelectedAuthor { get => selectedAuthor; set => selectedAuthor = value; }

        public GitBinderViewModel()
        {
            authors = new ObservableCollection<GitAuthorModel>();

            SelectCommand = new SimpleCommand(Select);
        }

        public void Select()
        {
            if (selectedAuthor == null)
                throw new NullReferenceException("No author selected");
            VMMediator.Instance.NotifyColleagues(MVVMMessage.AuthorSelected, selectedAuthor);
        }

        public void Close()
        {
            VMMediator.Instance.NotifyColleagues(MVVMMessage.CloseControl, this);
        }
    }
}
