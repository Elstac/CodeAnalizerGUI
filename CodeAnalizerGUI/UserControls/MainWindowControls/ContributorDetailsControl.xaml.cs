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
            if (contributorImage == null)
                contributorImage = StringToImageConverter.Convert(Directory.GetCurrentDirectory() + "\\nofile.png").Source;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
