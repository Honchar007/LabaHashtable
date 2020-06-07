using System;

namespace LabaHashTable
{
    
    public class Item
    {
        
        public string Key { get; private set; }


        
        public string Value { get; private set; }

        
        public Item(string key, string value)
        {
            Key = key;
            Value = value;
        }
        
        public override string ToString()
        {
            return Key;
        }
    }
}