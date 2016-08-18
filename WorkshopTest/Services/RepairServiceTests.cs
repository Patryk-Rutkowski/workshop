using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using Moq;
using WorkshopServices.Interface;
using System;
using Database.Interface;
using System.Collections.Generic;

namespace WorkshopServices.Implementation.Tests
{
    [TestClass()]
    public class RepairServiceTests
    {

        private RepairService _service;

        [TestMethod()]
        public void CreateNewRepairTest()
        {
            var result = new Mock<IRepairRepository>();
            List<DMLResult> testResult = new List<DMLResult>();
            testResult.Add(new DMLResult());
            testResult[0].Count = 1;
            result.Setup(x => x.CreateNewRepair(
                It.IsAny<string>(),
                It.IsAny<double>(),
                It.IsAny<int>(),
                It.IsAny<DateTime>(),
                It.IsAny<int>(),
                It.IsAny<double>(),
                It.IsAny<int[]>()
                )).Returns(testResult);

            _service = new RepairService(result.Object);
            var a = _service.CreateNewRepair("11111111111111111", 250, 350000, new DateTime(2016, 08, 17), 1, 2, new int[] { 1, 1 });
            Assert.IsNotNull(a);
            Assert.IsTrue(a.Success);
        }

        [TestMethod()]
        public void GetRepairHistoryByVinTest()
        {
            var result = new Mock<IRepairRepository>();
            List<RepairTablePresentation> history = new List<RepairTablePresentation>();
            result.Setup(x => x.GetRepairHistoryByVin(It.IsAny<string>()))
                        .Returns(history);
            _service = new RepairService(result.Object);

            var a = _service.GetRepairHistoryByVin("11111111111111111");
            Assert.IsNotNull(a);
            Assert.IsTrue(a.Success);
        }
    }
}