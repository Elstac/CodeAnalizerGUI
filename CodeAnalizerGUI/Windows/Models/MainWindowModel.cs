﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
namespace CodeAnalizerGUI.Windows.Models
{
    class MainWindowModel:Model
    {
        private UserControl content;
        public UserControl Content { get => content;set { content = value; RaisePropertyChanged("Content"); } }
    }
}
