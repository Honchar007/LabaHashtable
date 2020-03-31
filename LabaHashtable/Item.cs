using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaHashtable
{
    class Item
    {
        public string Key { get; private set;}
        public string Value { get; private set; }
        public Item(string key, string value)
        {
            key = Key;
            value = Value;
        }
        public override string ToString()
        {
            return Key;
        }
    }
}
