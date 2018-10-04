using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalizerGUI.Classes
{
    class ControlsChain
    {
        private ChainLink pointer;

        public ControlsChain()
        {

        }

        public ChainLink GetNextLink()
        {
            if (pointer.prev == null)
                throw new NullReferenceException("Reached chain end");
            pointer = pointer.prev;
            return pointer;
        }

        public void AddNewLink(ChainLink link)
        {
            if (pointer == null)
            {
                pointer = link;
            }
            else
            {
                link.prev = pointer;
                pointer = link;
            }

        }
    }
}
