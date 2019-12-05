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
            Assert.Equal(1,1);
            var myCollection = new MyCollection();
            while(myCollection.MoveNext()){
                Assert.NotNull(myCollection.Current);
            }

        }
    }
}
