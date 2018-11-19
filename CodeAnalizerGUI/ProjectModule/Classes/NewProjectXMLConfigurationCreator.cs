using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace CodeAnalizerGUI.ProjectModule
{
    public class NewProjectXMLConfigurationCreator : INewProjectConfigurationCreator
    {
        private XmlSerializer serializer;

        public ProjectConfig CreateConfiguration(string name, string description,string path)
        {
            throw new NotImplementedException();
        }
    }
}
