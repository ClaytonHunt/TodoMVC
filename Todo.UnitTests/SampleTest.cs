using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Todo.UnitTests
{
    [TestClass]
    public class SampleTest
    {
        [TestMethod]
        public void Sample()
        {
            var a = 1;
            Assert.AreEqual(2, a);
        }
    }
}
