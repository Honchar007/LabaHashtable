using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaHashTable
{
    class Program
    {
        static HashTable ReadText(HashTable hashTable)
        {
            string str = File.ReadAllText("test.txt");
            string[] wordSplit = str.Split(new char[] { '-', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < wordSplit.Length; i++)
            {
                hashTable.Insert(wordSplit[i], wordSplit[i+1]);
                i++;
            }
           
            
            return hashTable;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int n = 10000;
            var hashTable = new HashTable();
            hashTable = ReadText(hashTable);
           string s = Console.ReadLine();
            string[] wordSplit = s.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in wordSplit)
            {
                Console.WriteLine(hashTable.Search(item) );
            }
            Console.ReadLine();
            Console.WriteLine("Hello world");
            Console.ReadLine();
        }
    }
}
