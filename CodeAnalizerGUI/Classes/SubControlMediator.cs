﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeAnalizerGUI;
using CodeAnalizerGUI.Interfaces;
namespace CodeAnalizerGUI.Classes
{
    /// <summary>
    /// Manage sending/reciving data between controls. Use if higher mediator has managing datalistnig operation and its subcontrol needs data from other controls
    /// </summary>
    class SubControlMediator : ControlsMediator
    {
        private ISubControlOwner parent;
        public ISubControlOwner Parent { get => parent; set => parent = value; }

        public override void LoadContent(UserControl control)
        {
            parent.GetMediator().LoadContent(control);
        }
        
    }
}
