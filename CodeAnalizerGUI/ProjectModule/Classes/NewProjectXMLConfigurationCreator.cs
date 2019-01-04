using CodeAnalizerGUI.Interfaces;
using System.IO;
using System.Xml.Serialization;
namespace CodeAnalizerGUI.ProjectModule
{
    public class NewProjectXMLConfigurationCreator : INewProjectConfigurationCreator
    {
        private XmlSerializer serializer;
        private XmlSerializer contribSerializer;

        public NewProjectXMLConfigurationCreator()
        {
            serializer = new XmlSerializer(typeof(ProjectConfig));
            
        }

        public ProjectConfig CreateConfiguration(string name, string description,string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var ret = new ProjectConfig() { Name = name, Description = description, Directory = path };
            StreamWriter writer = new StreamWriter(path + "//Configuration.xml");
            serializer.Serialize(writer, ret);
            writer.Close();
            return ret;
        }
    }
}
