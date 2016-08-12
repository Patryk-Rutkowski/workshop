using System;
using System.Collections.Generic;
using Data;
using Extensions;
using WorkshopServices.Interface;
using Database;

namespace WorkshopServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository _categoryRepository)
        {
            this._categoryRepository = _categoryRepository;
        }

        public Result<DMLResult> CreateNewCategory(string name)
        {
            DMLResult insertResult = _categoryRepository.CreateNewCategory(name);
            Result<DMLResult> result = new Result<DMLResult>(insertResult);
            result.InsertCheck();
            return result;
        }

        public Result<List<Category>> GetAllCategories()
        {
            List<Category> categories = _categoryRepository.GetAllCategories();
            Result<List<Category>> result = new Result<List<Category>>(categories);
            result.ErrorIfDataNull();
            return result;
        }

        public Result<DMLResult> UpdateCategory(int id, string name)
        {
            throw new NotImplementedException();
        }
    }
}
