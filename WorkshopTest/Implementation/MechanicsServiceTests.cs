using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Database.Interface;
using Moq;
using Data;

namespace WorkshopServices.Implementation.Tests
{
    [TestClass()]
    public class MechanicsServiceTests
    {
        private MechanicsService _service;

        [TestMethod()]
        public void CreateNewMechanicTest()
        {
            var result = new Mock<IMechanicsRepository>();
            DMLResult insertResult = new DMLResult();
            insertResult.Count = 1;
            result.Setup(x => x.CreateNewMechanic(It.IsAny<string>(),
                                                  It.IsAny<double>()))
                        .Returns(insertResult);
            _service = new MechanicsService(result.Object);

            var a = _service.CreateNewMechanic("A", 1);
            Assert.IsNotNull(a);
            Assert.IsTrue(a.Success);
        }

        [TestMethod()]
        public void GetIdNameMechanicsTest()
        {
            var result = new Mock<IMechanicsRepository>();
            List<ComboBoxMechanic> mechanics = new List<ComboBoxMechanic>();
            result.Setup(x => x.GetIdNameMechanics())
                        .Returns(mechanics);
            _service = new MechanicsService(result.Object);

            var a = _service.GetIdNameMechanics();
            Assert.IsNotNull(a);
            Assert.IsTrue(a.Success);
        }
    }
}