using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Workshop;

namespace WorkshopTest
{
    /// <summary>
    /// Summary description for RepairHistoryModelViewTest
    /// </summary>
    [TestClass]
    public class RepairHistoryModelViewTest
    {
        [TestMethod()]
        public void ShowHistoryTest()
        {
            var actual = 9;
            RepairHistoryModelView show = new RepairHistoryModelView("11111111111111111");
            Assert.AreEqual(show.ShowHistory.Count, actual);
        }
    }
}
