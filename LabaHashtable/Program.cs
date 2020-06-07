using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaHashTable
{
    class Program
    {
        
        static void Main(string[] args)
        {int n = 10000;
            var hashTable = new HashTable();
            var rand = new Random();
            int x1,x2;
            for (int i = 0; i < n; i++)
            {
                x1 = rand.Next(0, n);
               

                hashTable.Insert(""+i, ""+i);
            }
                x2 = rand.Next(0, n);
           
            Console.WriteLine(hashTable.Search("" + x2));
            x2 = rand.Next(0, n);

            Console.WriteLine(hashTable.Search("" +x2));
            x2 = rand.Next(0, n);

            Console.WriteLine(hashTable.Search("" + x2));




            Console.ReadLine();




            Console.WriteLine("Hello world");
            Console.ReadLine();
        }
    }
}
