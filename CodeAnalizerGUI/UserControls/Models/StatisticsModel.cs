using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Abstractions;

namespace CodeAnalizerGUI.Models
{
    class StatisticsModel:Model
    {
        private string name;
        private object value;

        public StatisticsModel(string name, object value)
        {
            this.name = name;
            this.value = value;
        }

        public string Name { get => name; set { name = value; RaisePropertyChanged("Name"); } }
        public object Value { get => value; set { this.value = value; RaisePropertyChanged("Value"); } }
    }
}
