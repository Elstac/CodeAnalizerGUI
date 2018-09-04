using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizer;

namespace CodeAnalizerGUI
{
    public class OptionsHolder
    {
        private Language language;
        private string pathToData=".";
        public Language Language { get => language; set => language = value; }
        public string PathToData { get => pathToData; set => pathToData = value; }
    }
}
