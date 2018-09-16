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
namespace CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels
{
    class GitBinderViewModel
    {
        private GitAuthorModel selectedAuthor;
        private ObservableCollection<GitAuthorModel> authors;
        public ICommand SelectCommand { get; set; }
        private IControlsMediator mediator;

        public ObservableCollection<GitAuthorModel> Authors { get => authors; set { authors = value;} }
        public GitAuthorModel SelectedAuthor { get => selectedAuthor; set => selectedAuthor = value; }
        public IControlsMediator Mediator { get => mediator; set => mediator = value; }

        public GitBinderViewModel(AuthorInfo[] authors)
        {
            this.authors = new ObservableCollection<GitAuthorModel>();
            foreach (var author in authors)
            {
                this.authors.Add(new GitAuthorModel(author.name, author.email, author.commits.Count));
            }

            SelectCommand = new SimpleCommand(Select);
        }

        private void Select()
        {
            mediator.SendData(authors.IndexOf(selectedAuthor));
        }
    }
}
