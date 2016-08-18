using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Workshop;

namespace WorkshopTest.ModelView
{
    [TestClass]
    public class EditModelViewTest
    {
        [TestMethod]
        public void AllExistTest()
        {
            EditModelView show = new EditModelView("1","1","!",1,"1");
            var expected = true;
            var actual = show.AllExist();
            Assert.AreEqual(expected, actual);
        }
    }
}
