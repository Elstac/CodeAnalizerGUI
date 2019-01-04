using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CodeAnalizerGUI.DataSavingModule
{
    class XmlDataLoader<T> : ILoadBehavior<T>
    {
        private string path;
        private XmlSerializer serializer;

        public XmlDataLoader()
        {
            serializer = new XmlSerializer(typeof(T));
        }
        
        public T Load(string path)
        {
            StreamReader reader = new StreamReader(path);
            T ret= (T)serializer.Deserialize(reader);
            reader.Close();
            return ret;
        }
        
    }
}
