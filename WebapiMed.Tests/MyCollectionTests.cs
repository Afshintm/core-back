using System;
using Xunit;
using WebapiMed.Models;
namespace WebapiMed.Tests
{
    public class MyCollectionTests
    {
        [Fact]
        public void MyCollection_Should_Implement_IEnumerator()
        {
            var myCollection = new MyCollection();
            while(myCollection.MoveNext()){
                Assert.NotNull(myCollection.Current);
            }

        }

        [Fact]
        public void MyCollection_Indexer_Works_Fine(){
            var myCollection = new MyCollection() ;
            Assert.Equal("Item 1",myCollection[0].Name);

        } 

    }
}
