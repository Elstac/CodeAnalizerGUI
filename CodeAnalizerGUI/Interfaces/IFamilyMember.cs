using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalizerGUI.Interfaces
{
    /// <summary>
    /// Interface created to solve some control hierarchy problem:
    /// - window only windows owner
    /// - managing dependencies between controls and windows
    /// </summary>
    public interface IFamilyMember
    {
        /// <summary>
        /// Returns first member above in hierarchy mathing given type;
        /// </summary>
        /// <typeparam name="T">Type of member</typeparam>
        /// <param name="ret">Object containing returned parent</param>
        void GetParent<T>(ref T ret) where T:class;
    }
}
