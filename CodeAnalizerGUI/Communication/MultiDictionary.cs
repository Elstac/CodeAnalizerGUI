using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalizerGUI
{
    class MultiDictionary<K,V> : Dictionary<K,List<V>>
    {
        public void AddValue(K key,V value)
        {
            if (!ContainsKey(key))
                this[key] = new List<V>();

            this[key].Add(value);
        }

        public void RemoveValue(K key,V value)
        {
            if (!ContainsKey(key))
                return;

            this[key].Remove(value);
        }

        public void ClearKey(K key)
        {
            if (!ContainsKey(key))
                return;

            this[key].Clear();
        }
    }
}
