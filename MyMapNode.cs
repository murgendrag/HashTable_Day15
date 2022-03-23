using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable_Day15
{
    public class MyMapNode<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValuePair<K, V>>[] items;

        public MyMapNode(int size)  //constructor
        {
            this.size = size;
            this.items = new LinkedList<KeyValuePair<K, V>>[size];
        }

        protected int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<K, V>> linkedlist = GetLinkedlist(position);
            foreach (KeyValuePair<K, V> item in linkedlist)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }

            }
            return default(V);
        }

        public void Add(K key, V Value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<K, V>> Linkedlist = GetLinkedlist(position);
            KeyValuePair<K, V> item = new KeyValuePair<K, V> { Key = key, Value = Value };
            Linkedlist.AddLast(item);
        }
        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<K, V>> LinkedList = GetLinkedlist(position);
            bool itemFound = false;
            KeyValuePair<K, V> founditem = default(KeyValuePair<K, V>);
            foreach (KeyValuePair<K, V> item in LinkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    founditem = item;
                }
            }
            if(itemFound)
            {
                LinkedList.Remove(founditem);
            }
        }
    
        protected LinkedList<KeyValuePair<K, V>> GetLinkedlist(int position)
        {
            LinkedList<KeyValuePair<K, V>> linkedlist = items[position];
            if (linkedlist == null)
            {
                linkedlist = new LinkedList<KeyValuePair<K, V>>();
                items[position] = linkedlist;
            }
            return linkedlist;
        }

    }


        /// <summary>
        /// data structure
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        public struct KeyValuePair<K, V>  
        {
            public K Key { get; set; }
            public V Value { get; set; }
        }
}
