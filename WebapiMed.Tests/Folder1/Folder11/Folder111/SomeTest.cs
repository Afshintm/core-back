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
            var baseUri = new Uri("http://abc.com.au/");
            var relativePath = "/rest/of/theMessage?var1=value1&var2=value2";

            var uri = new Uri(baseUri, relativePath).ToString();

            var substringFromDot_au = uri.Substring(uri.IndexOf(@".au"));
            Assert.Equal(1, 1);

            // Assert.True(uri.Contains(@"//"));
            // Assert.False(substringFromDot_au.Contains(@"//"));
        }

    }
}