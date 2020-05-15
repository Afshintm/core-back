using System;
using System.Threading;
using Xunit;
namespace WebapiMed.Tests.Folder1.Folder11.Folder111
{
    public class SomeTests
    {
        public SomeTests() { }
        [Fact]
        public void Test_Should_Run_Within_Nested_Folders()
        {
            //Given
            var str = "Hello";
            //When

            //Then
            Assert.Equal("Hello", str);
        }
        [Fact]
        public void Uri_Builder_Test_Removes_double_Slashes()
        {
            Thread.Sleep(15000);
            var baseUri = new Uri("http://abc.com.au/");
            var relativePath = "/rset/of/theMessage?var1=value1&var2=value2";
            var uri = new Uri(baseUri, relativePath).ToString();
            Assert.NotNull(uri);
        }

    }
}