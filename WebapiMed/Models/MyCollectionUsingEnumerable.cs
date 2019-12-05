using System.Collections;
using System.Collections.Generic;
namespace WebapiMed.Models{

    public class MyCollectionUsingEnumerable : IEnumerable<Item>
    {
        private List<Item> _items = new List<Item>
            {
                new Item{Id=0,Name="Item 0"},
                new Item{Id=1,Name="Item 1"},
                new Item{Id=2,Name="Item 2"}
            };
            
        public IEnumerator<Item> GetEnumerator()
        {
            return _items.GetEnumerator(); 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator() ;
        }
    }


}