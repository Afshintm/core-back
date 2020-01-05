using Xunit;
using WebapiMed.Models;
using System.Linq;

namespace WebapiMed.Tests
{
    public class MyCollectionTests
    {
        [Fact]
        public void MyCollection_Should_Implement_IEnumerator()
        {
            var myCollection = new MyCollection(); while (myCollection.MoveNext())
            { Assert.NotNull(myCollection.Current); }

        }

        [Fact]
        public void MyCollection_Indexer_Works_Fine()
        {
            var myCollection = new MyCollection();
            Assert.Equal("Item 0", myCollection[0].Name);

        }

        [Fact]
        public void MyCollection_Indexer_Should_be_Able_To_Add_New_Item()
        {
            var myCollection = new MyCollection(); myCollection[3] = new Item { Id = 3, Name = "Item 3" }; var i = -1;
            while (myCollection.MoveNext()) { Assert.Equal($"Item {++i}", myCollection.Current.Name); }

        }

        [Fact]
        public void MyCollection_Should_Work_With_Foreach()
        {
            var myCollection = new MyCollection();
            myCollection[3] = new Item { Id = 3, Name = "Item 3" };
            foreach (var item in myCollection)
            {
                Assert.NotNull(item);
            }

        }

        [Fact]
        public void MyCollection_Should_Work_With_Linq()
        {
            var myCollection = new MyCollection();
            myCollection[3] = new Item { Id = 3, Name = "Item 3" };
            Assert.NotNull(myCollection.FirstOrDefault(i => i.Id == 3));

        }
    }
}
