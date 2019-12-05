using System;
using System.Collections;
using System.Collections.Generic;

namespace WebapiMed.Models
{
    public class Item{
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString(){
            return Name;
        }
    }
    public class MyCollection : IEnumerator<Item>
    {
        private int _index = -1; 
        private Item[] _items = new Item[]
        {
            new Item{Id=1,Name="Item 1"},
            new Item{Id=2,Name="Item 2"},
            new Item{Id=3,Name="Item 3"}
        };

        public Item Current  { 
            get
            {
                try{
                    return _items[_index];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current {get{return Current;} }

        public void Dispose()
        {
            _items = null;
        }

        public bool MoveNext()
        {
            //move to next item and return false as soon as we pass the number of items 
            _index++ ;
            return  (_index < _items.Length);
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}