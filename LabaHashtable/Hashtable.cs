using System;
using System.Collections.Generic;
using System.Linq;

namespace LabaHashTable
{
    
    
    public class HashTable
    {
        int counter = 1;
        
        private readonly byte _maxSize = 200;

        private Dictionary<int, List<Item>> _items = null;

        //public IReadOnlyCollection<KeyValuePair<int, List<Item>>> Items => _items?.ToList()?.AsReadOnly();
        public class Node
{
    public Node next;
    public Object data;
}

public class LinkedList
{
    private Node head;

    public void printAllNodes()
    {
        Node current = head;
        while (current != null)
        {
            Console.WriteLine(current.data);
            current = current.next;
        }
    }

    public void AddFirst(Object data)
    {
        Node toAdd = new Node();

        toAdd.data = data;
        toAdd.next = head;

        head = toAdd;
    }

    public void AddLast(Object data)
    {
        if (head == null)
        {
            head = new Node();

            head.data = data;
            head.next = null;
        }
        else
        {
            Node toAdd = new Node();
            toAdd.data = data;

            Node current = head;
            while (current.next != null)
            {
                current = current.next;
            }

            current.next = toAdd;
        }
    }
}

        public HashTable()
        {
           
            _items = new Dictionary<int, List<Item>>(_maxSize); //////////////////////////////////
        }

        public void Insert(string key, string value)
        {
            
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (key.Length > _maxSize)
            {
                throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(key));
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            var item = new Item(key, value);

            
            var hash = GetHash(item.Key);

           
            List<Item> hashTableItem = null;
            if (_items.ContainsKey(hash))
            {
                
                hashTableItem = _items[hash];
                
                var oldElementWithKey = hashTableItem.SingleOrDefault(i => i.Key == item.Key);
                if (oldElementWithKey != null)
                {
                    throw new ArgumentException($"Хеш-таблица уже содержит элемент с ключом {key}. Ключ должен быть уникален.", nameof(key));
                }

                
                _items[hash].Add(item);
            }
            else
            {
                
                hashTableItem = new List<Item> { item }; //////////////////////////////////////////

                
                _items.Add(hash, hashTableItem);
            }
        }
        public void Delete(string key)
        {
           
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (key.Length > _maxSize)
            {
                throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(key));
            }
            var hash = GetHash(key);
            if (!_items.ContainsKey(hash))
            {
                return;
            }
            var hashTableItem = _items[hash];
            var item = hashTableItem.SingleOrDefault(i => i.Key == key);
            
            if (item != null)
            {
                hashTableItem.Remove(item);
            }
        }
        public string Search(string key)
        {
            
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (key.Length > _maxSize)
            {
                throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(key));
            }
            var hash = GetHash(key);
            
            //Console.WriteLine(hash);
            if (!_items.ContainsKey(hash))
            {
                
                return null;
            }
            var hashTableItem = _items[hash];
           
            if (hashTableItem != null)
            {
                
                
              // var item = hashTableItem.SingleOrDefault(i => i.Key == key);
                foreach (var i in hashTableItem)
                {
                    if(i.Key == key)
                    {
                        Console.WriteLine("Counter:"+counter+"VALUE"+hash);
                        return i.Value;
                    }
                    else
                    {
                        counter++;
                    }
                    
                }
                    

                
                /*if (item != null)
                {
                    
                    return item.Value;
                }*/
            }
            return null;
        }
        /*
         function get(key)
  index = get_hash(key)
  for (i=index mod capacity,x=0;;i=(index+x) mod capacity,x=x+1)
    if table[index] == null 
        error “Invalid key”
    end if
    else if table[index].key == key
        return table[i].value
    end else if
  end for
end functio
*/
        public  int get(string key)
        {
            int index = GetHash(key);
            

            for (int i = index % _maxSize, x = 0; ; i = (index + x) % _maxSize, x = x + 1)
            {
                var hashTableItem = _items[index];
                if (hashTableItem == null)
                {
                    Console.WriteLine("ERROR INVALID KEY");
                    return 0;
                }

                if (hashTableItem[index].Key == key)
                {Console.WriteLine(x + 1);

                }
                Console.WriteLine(hashTableItem[0].Value);
                 
               
                
               
            }
        }
        private int GetHash(string value)
        {
            MurmurHash2Simple simple = new MurmurHash2Simple();
            
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.Length > _maxSize)
            {
                throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(value));
            }

            
            var hash =Convert.ToInt32( simple.Hash(System.Text.Encoding.UTF8.GetBytes(value)));
            
            return hash;
        }
        public class MurmurHash2Simple 
        {
            public UInt32 Hash(Byte[] data)
            {
                return Hash(data, 0xc58f1a7b);
            }
            const UInt32 m = 0x5bd1e995;
            const Int32 r = 24;

            public UInt32 Hash(Byte[] data, UInt32 seed)
            {
                Int32 length = data.Length;
                if (length == 0)
                    return 0;
                UInt32 h = seed ^ (UInt32)length;
                Int32 currentIndex = 0;
                while (length >= 4)
                {
                    UInt32 k = BitConverter.ToUInt32(data, currentIndex);
                    k *= m;
                    k ^= k >> r;
                    k *= m;

                    h *= m;
                    h ^= k;
                    currentIndex += 4;
                    length -= 4;
                }
                switch (length)
                {
                    case 3:
                        h ^= BitConverter.ToUInt16(data, currentIndex);
                        h ^= (UInt32)data[currentIndex + 2] << 16;
                        h *= m;
                        break;
                    case 2:
                        h ^= BitConverter.ToUInt16(data, currentIndex);
                        h *= m;
                        break;
                    case 1:
                        h ^= data[currentIndex];
                        h *= m;
                        break;
                    default:
                        break;
                }

                // Do a few final mixes of the hash to ensure the last few
                // bytes are well-incorporated.

                h ^= h >> 13;
                h *= m;
                h ^= h >> 15;

                return h/10000;
            }
        }
    }
}