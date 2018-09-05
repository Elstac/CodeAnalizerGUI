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
using CodeAnalizer;
using CodeAnalizerGUI.Classes.Converters;
using System.IO;
namespace CodeAnalizerGUI.UserControls.MainWindowControls
{
    /// <summary>
    /// Interaction logic for ContributorDetailsControl.xaml
    /// </summary>
    public partial class ContributorDetailsControl : UserControl
    {
        private Contributor contributor;
        private ImageSource contributorImage;
        private string contributorName;

        public ContributorDetailsControl()
        {
            InitializeComponent();
            MainImage.DataContext = this;
            NameBlock.DataContext = this;
            contributorImage = StringToImageConverter.Convert(Directory.GetCurrentDirectory() + "\\nofile.png").Source;
        }

        public Contributor Contributor
        {
            get => contributor;
            set
            {
                contributor = value;
                contributorName = contributor.Name;
            }
        }
        public ImageSource ContributorImage { get => contributorImage; set => contributorImage = value; }
        public string ContributorName { get => contributorName; set => contributorName = value; }

        public void LoadContent()
        {
            if (contributor == null)
                throw new MissingMemberException("Contributor not set");
            LoadBasicStats();
        }

        private void LoadBasicStats()
        {
            FileAnalizer analizer = contributor.Analizer;
            
            AddNewBlockN("Characters: " + analizer.GetCharacktersCount());
            AddNewBlockN("Lines: " + analizer.GetLinesCount());
            AddNewBlockN("Usings: " + analizer.GetUsingsCount());
            AddNewBlockN("Empty lines: " + analizer.GetEmptyLines()); 
            AddNewBlockN("Largest file: " + analizer.GetLargestFile());
            AddNewBlockN("Smallest file: " + analizer.GetSmallestFile());
            AddNewBlockN("Methods: " + analizer.GetMethodsCount());
        }

        private void AddNewBlockN(string text)
        {
            if (text == null || text == "")
                return;
            TextBlock block = new TextBlock();
            block.Text = text;
            NumberPanel.Children.Add(block);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
