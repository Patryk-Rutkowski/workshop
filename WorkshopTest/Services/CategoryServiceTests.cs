using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using Database;
using Moq;
using System.Collections.Generic;

namespace WorkshopServices.Tests
{
    [TestClass()]
    public class CategoryServiceTests
    {
        private CategoryService _service;

        [TestMethod()]
        public void GetAllCategoriesTest()
        {
            var result = new Mock<ICategoryRepository>();
            Category category = new Category();
            List<Category> categoryList = new List<Category>();
            categoryList.Add(category);
            result.Setup(x => x.GetAllCategories());
            _service = new CategoryService(result.Object);

            var a = _service.GetAllCategories();
            Assert.IsNotNull(a);
            Assert.IsTrue(!a.Success);
        }
    }
}