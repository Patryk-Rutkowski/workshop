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
        public void GetByModelMarkYearbookTest()
        {
            var result = new Mock<ICarRepository>();
            Car car = new Car();
            List<Car> carList = new List<Car>();
            carList.Add(car);
            result.Setup(x => x.GetByMakeModelYearbook(It.IsAny<string>(),
                                                       It.IsAny<string>(),
                                                       It.IsAny<int>()))
                        .Returns(new List<Car>());
            _service = new CarService(result.Object);

            var a = _service.GetByModelMarkYearbook("Honda", "Accord", 2003);
            Assert.IsNotNull(a);
            Assert.IsTrue(a.Success);
        }

        [TestMethod()]
        public void GetByVinTest()
        {
            var result = new Mock<ICarRepository>();
            result.Setup(x => x.GetByVin(It.IsAny<string>())).Returns((Car)null);
            _service = new CarService(result.Object);

            var a = _service.GetByVin("11111111111111111");
            Assert.IsNull(a.Data);
            //Assert.IsTrue(a.Success);
        }

        [TestMethod()]
        public void CreateNewCarTest()
        {
            var result = new Mock<ICarRepository>();
            DMLResult testResult = new DMLResult();
            testResult.Count = 1;
            result.Setup(x => x.CreateCar(It.IsAny<string>(),
                                          It.IsAny<string>(),
                                          It.IsAny<int>(),
                                          It.IsAny<string>(),
                                          It.IsAny<string>()))
                         .Returns(testResult);

            _service = new CarService(result.Object);
            var a = _service.CreateNewCar("Honda", "Accord", 2003, "2.0", "111");
            Assert.IsNotNull(a);
            Assert.IsTrue(a.Success);
        }

        [TestMethod()]
        public void GetAvailableMakesTest()
        {
            var result = new Mock<ICarRepository>();
            List<Make> makes = new List<Make>();
            result.Setup(x => x.GetAvailableMakes()).Returns(makes);

            _service = new CarService(result.Object);
            var a = _service.GetAvailableMakes();
            Assert.IsNotNull(a);
            Assert.IsTrue(a.Success);
        }

        [TestMethod()]
        public void GetModelByMakeTest()
        {
            var result = new Mock<ICarRepository>();
            List<CarModel> models = new List<CarModel>();
            result.Setup(x => x.GetModelByMake(It.IsAny<string>())).Returns(models);

            _service = new CarService(result.Object);
            var a = _service.GetModelByMake("Honda");
            Assert.IsNotNull(a);
            Assert.IsTrue(a.Success);
        }
    }
}