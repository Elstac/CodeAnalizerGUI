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
using System.IO;
namespace CodeAnalizerGUI
{
    /// <summary>
    /// Interaction logic for NewContributorControl.xaml
    /// </summary>
    public partial class NewContributorControl : UserControl,IFileExplorerUser
    {
        private IControlsMediator mediator;
        private string contributorName = "name";
        private string lastName = "lastname";
        private string pathToImage;
        private List<string> files = new List<string>() {};
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
        public string LastName { get => lastName; set => lastName = value; }
        public List<string> Files { get => files; }
        public string PathToImage { get => pathToImage; set => pathToImage = value; }
        internal IControlsMediator Mediator {set => mediator = value; }

        private void ChoseImageButtonClick(object sender, RoutedEventArgs e)
        {
            //FileExplorerWindow win = new FileExplorerWindow(this, point,new string[] {".jpg", ".png", ".bmp"});
            //win.Show();
        }
        
        private void ConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            if (PathToImage == null)
                PathToImage = Directory.GetCurrentDirectory() + "\\nofile.png";

            string[] files = FileList.Files.ToArray();
            ContributorDisplay tmp = new ContributorDisplay();
            tmp.name = Name + " " + LastName;
            tmp.pathToImage = PathToImage;
            mediator.SendData(tmp);
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
    }
}
