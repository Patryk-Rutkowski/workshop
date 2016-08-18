using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using Moq;

namespace Workshop
{
    [TestClass]
    public class AddRepairModelViewTest
    {
        [TestMethod]
        public void CheckValueTest()
        {
            AddRepairModelView show = new AddRepairModelView("122131");
            ComboBoxPart tr = new ComboBoxPart();
            tr.Name = "1";
            tr.Id = 1;
            show.SelectedPart = tr;
            var expected = show.CheckValue();
            var actual = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CheckAllTest()
        {
            AddRepairModelView show = new AddRepairModelView("122131");
            ComboBoxPart tr = new ComboBoxPart();
            var expected = false;
            show.CenaCzesci = 1;
            show.CenaNaprawy = 1;
            show.Przebieg = "1";
            show.Data = new DateTime(2008,01,02);
            //show.czesci.Add = 1;
            var actual = show.CheckAll();
            Assert.AreEqual(expected, actual);
        }
    }
}
