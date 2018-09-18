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
namespace CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels
{
    public class GitBinderViewModel:ViewModel
    {
       
        private GitAuthorModel selectedAuthor;
        private ObservableCollection<GitAuthorModel> authors;
        public ICommand SelectCommand { get; set; }
        private IControlsMediator mediator;

        public ObservableCollection<GitAuthorModel> Authors { get => authors; set { authors = value;} }
        public GitAuthorModel SelectedAuthor { get => selectedAuthor; set => selectedAuthor = value; }
        public IControlsMediator Mediator { get => mediator; set => mediator = value; }

        public GitBinderViewModel(GitAuthorModel[] authors)
        {
            this.authors = new ObservableCollection<GitAuthorModel>();
            foreach (var author in authors)
            {
                this.authors.Add(author);
            }

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
            mediator.CloseControl(this);
        }
    }
}
