using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using CodeAnalizerGUI.UserControls.MainWindowControls.Commands;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizer.GitTrackerModule.Classes;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using CodeAnalizerGUI.Abstractions;
namespace CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels
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
            mediator.SendData(authors.IndexOf(selectedAuthor));
        }

        public void Close()
        {
            mediator.CloseControl();
        }
    }
}
