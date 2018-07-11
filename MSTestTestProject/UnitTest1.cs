using Fresnel.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTestTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StartsWithText()
        {
            string x1 = "Action";
            string x2 = "Action Point";
            StringAssert.StartsWith(x2, x1);
        }
        [TestMethod]
        public void ConfigString()
        {
            Assert.AreEqual("http://jsonplaceholder.typicode.com/users", Configuration.ApiBaseUrl);
        }
    }
}
