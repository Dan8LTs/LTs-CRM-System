﻿using CrmBl.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

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
            Thread.Sleep(10000);
        }
    }
}