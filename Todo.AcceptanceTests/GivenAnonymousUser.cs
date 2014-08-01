using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium;

namespace Todo.AcceptanceTests
{
    [TestClass]
    public class GivenAnonymousUser
    {
        private ISelenium _selenium;

        [TestInitialize]
        public void Setup()
        {
            SeleniumServer.Start();
            _selenium = new DefaultSelenium("localhost", 4444, "*chrome", ConfigurationManager.AppSettings["testSite"]);
            _selenium.Start();            
        }

        [TestCleanup]
        public void TearDown()
        {
            _selenium.Stop();
            SeleniumServer.Stop();        
        }

        [TestMethod]
        public void ThenUserCanRegister()
        {
            _selenium.Open("/");
        }
    }
}
