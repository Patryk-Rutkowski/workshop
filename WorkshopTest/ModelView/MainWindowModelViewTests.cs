using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using System.Threading.Tasks;
using Data;
using WorkshopServices;
using WorkshopServices.Implementation;
using Database;

namespace Workshop.ViewModel
{
    [TestClass()]
     public class MainWindowModelViewTests
    {
        MainWindowModelView show;

        [TestMethod()]
        public void GetCarTest()
        {
           var result = new MainWindowModelView().GetAllMake();
            var resulT = new Mock<MainWindowModelView>();
            List<Car> list = new List<Car>();
            var actual = 8;
           // resulT.Setup(x => x.GetCarClick()).Returns(list);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, actual);
        }
        [TestMethod()]
        public void GetDateTest()
        {
            var result = new Mock<MainWindowModelView>();
            var lis = new List<int>();
           // result.Verify(x => x.year);
           show = new MainWindowModelView();
            var actual = 67;
            var a = show.GetDate();
            Assert.IsNotNull(a);
            Assert.AreEqual(a.Count, actual);
        }

        [TestMethod()]
        public void AllSelectedTest()
        {
            MainWindowModelView show = new MainWindowModelView();
            show.selectedMakeIndex = 1;
            show.selectedModelIndex = 1;
            show.SelectedYearbook = 1;
            var expected = true;
            var actual = show.AllSelected();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void SelectedCarMakeTestt()
        {
            MainWindowModelView show = new MainWindowModelView();
            show.selectedMakeIndex = 1;
            var expected = true;
            var actual = show.SelectedCarMake();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetAllMakeTest()
        {
            MainWindowModelView show = new MainWindowModelView();
            var expected = 8;
            var actual = show.GetAllMake();
            Assert.AreEqual(actual.Count, expected);
        }
        [TestMethod()]
        public void GetCarClickTest()
        {
            MainWindowModelView show = new MainWindowModelView();
            show.car__.Vin = "206548B3754F44229";
            var expected = 1;
            var actual = show.GetCarClick();
            Assert.AreEqual(expected, actual.Count);
        }
        [TestMethod()]
        public void GetCarMakeModelYearbookTest()
        {
            MainWindowModelView show = new MainWindowModelView();
            show.SelectedMake = "Honda";
            show.SelectedModel = "Accord";
            show.SelectedYearbook = 2003;
            var expected = 1;
            var actual = show.GetCarMakeModelYearbook();
            Assert.AreEqual(actual.Count, expected);
        }

        [TestMethod()]
        public void GetAllModelHondaTest()
        {
            MainWindowModelView show = new MainWindowModelView();
            show.selectedMakeIndex = 1;
            show.SelectedMake = "Honda";
            var expected = 4;
            var actual = show.GetAllModel();
            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod()]
        public void GetAllModelBMWTest()
        {
            MainWindowModelView show = new MainWindowModelView();
            show.selectedMakeIndex = 3;
            show.SelectedMake = "BMW";
            var expected = 3;
            var actual = show.GetAllModel();
            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod()]
        public void GetAllModelSaabTest()
        {
            MainWindowModelView show = new MainWindowModelView();
            show.selectedMakeIndex = 1;
            show.SelectedMake = "Saab";
            var expected = 2;
            var actual = show.GetAllModel();
            Assert.AreEqual(expected, actual.Count);
        }
        [TestMethod()]
        public void GetAllModelOpelTest()
        {
            MainWindowModelView show = new MainWindowModelView();
            show.selectedMakeIndex = 3;
            show.SelectedMake = "Opel";
            var expected = 3;
            var actual = show.GetAllModel();
            Assert.AreEqual(expected, actual.Count);
        }
    }
}
