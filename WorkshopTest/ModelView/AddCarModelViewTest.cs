using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Workshop.ViewModel
{
    [TestClass]
    public class AddCarModelViewTest
    {
        [TestMethod]
        public void AllExistsTest()
        {
            AddCarModelView show = new AddCarModelView();
            show.Make = "1";
            show.Model = "1";
            show.Vin = "1";
            show.Engine = "1";
            show.Year = 1;
            var actual = show.AllExist();
            var expected = true;
            Assert.AreEqual(actual, expected);
        }
    }
}
