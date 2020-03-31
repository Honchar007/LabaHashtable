using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaHashtable
{
    class Hashtable<TKey,TValue>
    {
        private List<TValue>[] items;
        public Hashtable(int size)
        {
            items = List<TValue>();
        }
        public void Add(T item)
        {
            var key = GetHash(item);
            items[key] = item;
        }
        public void Search(T item)
        {
            var key = GetHash(item);
            if (items[key] != null) Console.WriteLine(items[key]); 

        }
        private int GetHash(T item)
        {
            return item.ToString().Length % items.Length;
        }
    }
}
