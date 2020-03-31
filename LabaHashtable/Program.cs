using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaHashtable
{
    class Program
    {
        static void Main(string[] args)
        {
            var badHashTable = new Hashtable<int>(100);
            badHashTable.Add(5);
            badHashTable.Add(18);
            badHashTable.Add(777);
            badHashTable.Search(10);
            Console.WriteLine("Hello world");
            Console.ReadLine();
        }
    }
}
