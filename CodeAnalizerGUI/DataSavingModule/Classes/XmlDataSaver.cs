using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace CodeAnalizerGUI.DataSavingModule
{
    class XmlDataSaver<T> : ISaveBehavior<T>
    {
        private XmlSerializer serializer;

        public XmlDataSaver()
        {
            serializer = new XmlSerializer(typeof(T));
        }

        public void Save(T dataObject,string path)
        {
            StreamWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, dataObject);
            writer.Close();
        }
        
    }
}
