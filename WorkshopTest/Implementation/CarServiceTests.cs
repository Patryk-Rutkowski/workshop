using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using Moq;
using System.Collections.Generic;

namespace WorkshopServices.Implementation.Tests
{
    [TestClass()]
    public class CarServiceTests
    {

        private CarService _service;


        [TestMethod()]
        public void CarServiceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetByModelMarkYearbookTest()
        {
            var result = new Mock<ICarRepository>();
            Car car = new Car();
            List<Car> carList = new List<Car>();
            carList.Add(car);
            result.Setup(x => x.GetByMakeModelYearbook(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new List<Car>());
            _service = new CarService(result.Object);
            //var a = _service.GetByModelMarkYearbook("Honda", "Accord", 2003);

            //Assert.IsNotNull(a);
        }

        [TestMethod()]
        public void GetByVinTest()
        {
            var result = new Mock<ICarRepository>();
            result.Setup(x => x.GetByVin(It.IsAny<string>())).Returns((Car)null);
            _service = new CarService(result.Object);
            //var a = _service.GetByVin("11111111111111111");
            //Assert.IsNull(a);
            //Assert.IsTrue(a.Vin == "11111111111111111");
        }
    }
}