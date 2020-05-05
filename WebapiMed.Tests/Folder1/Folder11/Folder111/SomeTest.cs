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

    }
}