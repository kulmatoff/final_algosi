using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Сделать IncreaseCapacity
// Сделать IncreaseCapacity
// Сделать IncreaseCapacity
// Сделать IncreaseCapacity
// Сделать IncreaseCapacity
// Сделать IncreaseCapacity

namespace Final_ALgosi
{
    internal class HashTable
    {
        int _count;
        int _capacity;
        LinkedList<Item>[] list;

        public HashTable(int size)
        {
            _capacity = size;
            _count = 0;
            list = new LinkedList<Item>[_capacity];
            for (int i = 0; i < _capacity; i++)
            {
                list[i] = new LinkedList<Item>();
            }
        }

        public List<Item> GetElements()
        {
            List<Item> items = new List<Item>();
            foreach (LinkedList<Item> l in list)
            {
                foreach (Item item in l)
                {
                    items.Add(item);
                }
            }
            return items;
        }

        public bool Remove(string key)
        {
            int index = GetIndex(key);

            foreach (Item item in list[index])
            {
                if (item.key == key) { list[index].Remove(item); _count--; return true; }
            }
            return false;
        }

        public string this[string key]
        {
            get
            {
                return GetValue(key);
            }
            set
            {
                if (Contains(key))
                {
                    ChangeValue(key, value);
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        public string GetValue(string key)
        {
            int index = GetIndex(key);
            foreach (Item item in list[index])
            {
                if (item.key == key) return item.value;
            }
            throw new IndexOutOfRangeException();
        }

        public void Add(string key, string value)
        {
            Item item = new Item(key, value);
            int index = GetIndex(key);
            list[index].AddLast(item);
            _count++;
        }

        public void ChangeValue(string key, string value)
        {
            int index = GetIndex(key);
            foreach (Item item in list[index])
            {
                if (item.key == key)
                {
                    item.value = value;
                }
            }
        }

        public bool Contains(string key)
        {
            int index = GetIndex(key);
            foreach (Item item in list[index])
            {
                if (item.key == key) return true;
            }
            return false;
        }

        public int GetIndex(string value) { return HashFunc(value) % _capacity; }

        public int HashFunc(string value)
        {
            int result = 0;
            foreach (char c in value)
            {
                result += c;
            }
            return result;
        }
    }

    class Item
    {
        public string value;
        public string key;

        public Item(string key, string value)
        {
            this.value = value;
            this.key = key;
        }
    }
}
