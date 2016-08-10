using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;

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
            Assert.Fail();
        }

        [TestMethod()]
        public void GetByVinTest()
        {
            var result = new Mock<ICarRepository>();
            Car car = new Car();
            car.Vin = "11111111111111111";
            result.Setup(x => x.GetByVin(It.IsAny<string>())).Returns(car);
            _service = new CarService(result.Object);
            var a = _service.GetByVin("11111111111111111");
            Assert.IsNotNull(a.Vin);
            Assert.IsTrue(a.Vin == "11111111111111111");
        }
    }
}