using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using CodeAnalizerGUI.Classes.Converters;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Classes.MinorClasses;
using CodeAnalizer.GitTrackerModule.Classes;
using System.IO;
using CodeAnalizerGUI.UserControls.MainWindowControls;
namespace CodeAnalizerGUI
{
    /// <summary>
    /// Interaction logic for NewContributorControl.xaml
    /// </summary>
    public partial class NewContributorControl : UserControl,IFileExplorerUser,ISubControlDataReciver
    {
        private IControlsMediator mediator;
        private string contributorName = "name";
        private string email = "email";
        private string pathToImage;
        private List<string> files = new List<string>() {};
        private UserControl treeParent;
        public NewContributorControl()
        {
            InitializeComponent();
            ContributorImage.Source = StringToImageConverter.Convert(Directory.GetCurrentDirectory() + "\\plus.png").Source;
            Control tmp;
           

            foreach (var item in IdPanel.Children)
            {
                if (!(item is Control))
                    continue;
                tmp = item as Control;
                tmp.DataContext = this;
            }
        }

        public string ContributorName { get => contributorName; set => contributorName = value; }
        public string Email { get => email; set => email = value; }
        public List<string> Files { get => files; }
        public string PathToImage { get => pathToImage; set => pathToImage = value; }
        internal IControlsMediator Mediator {set => mediator = value; }
        public UserControl TreeParent { get => treeParent; set => treeParent = value; }

        private void ChoseImageButtonClick(object sender, RoutedEventArgs e)
        {
            FileExplorerControl fec = new FileExplorerControl();
            fec.Mediator = mediator;
            fec.TreeParent = this;
            mediator.LoadContent(fec);
        }
        
        private void ConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            if (PathToImage == null)
                PathToImage = Directory.GetCurrentDirectory() + "\\nofile.png";

            string[] files = FileList.Files.ToArray();
            ContributorDisplay tmp = new ContributorDisplay();
            tmp.name = Name;
            tmp.pathToImage = PathToImage;
            tmp.email = email;
            mediator.SendData(tmp);
            mediator.LoadContent(treeParent);
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            throw new InvalidOperationException();
        }

        private void GetGitButtonClick(object sender, RoutedEventArgs e)
        {
            
        }


        public void GetFileExplorerResults(string retPath)
        {
            PathToImage = retPath;
            ContributorImage.Source = StringToImageConverter.Convert(retPath).Source;
        }

        public void ReciveData(object dataClass)
        {
            if( dataClass is string)
            {
                pathToImage = dataClass.ToString();
                return;
            }
            AuthorInfo info = dataClass as AuthorInfo;

            Name = info.name;
            email = info.email;
        }
    }
}
