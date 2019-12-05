using WebapiMed.Models;
using Xunit;

public class MyCollectionUsingEnumerableTests{
    [Fact]
    public void MyCollectionUsingEnumerable_Should_Wor_With_Foreach(){
        var mycollectyionUsingIEnumerable = new MyCollectionUsingEnumerable() ;
        foreach (var item in mycollectyionUsingIEnumerable)
        {
            Assert.NotNull(item);
        }
    }
    
}