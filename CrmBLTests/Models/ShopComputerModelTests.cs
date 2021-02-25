using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BL.Models.Tests
{
    [TestClass()]
    public class ShopComputerModelTests
    {
        [TestMethod()]
        public void StartTest()
        {
            var model = new ShopComputerModel();
            model.Start();
        }
    }
}