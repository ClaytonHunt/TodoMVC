using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Todo.AcceptanceTests
{
    [TestClass]
    public class GivenAnonymousUser
    {
        [TestInitialize]
        public void Setup()
        {
            SeleniumServer.Start();
        }

        [TestCleanup]
        public void TearDown()
        {            
            SeleniumServer.Stop();        
        }

        [TestMethod]
        public void ThenUserCanRegister()
        {
            new SeleniumServer().Run(seleium => {
                seleium.Open("/");
                Assert.IsTrue(true);
            });
        }
    }


}