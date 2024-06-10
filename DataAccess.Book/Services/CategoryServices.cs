using DataAccess.Book.DTO;
using DataAccess.BookStore.DBContext;
using DataAccess.BookStore.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Book.Services
{
    public class CategoryServices
    {
        private readonly EBookDBContext _eBookDbContext;

        public CategoryServices()
        {
            _eBookDbContext = new EBookDBContext();
        }

        public async Task<CategoryReturnData> AddCategoryAsync(CategoryRequestData requestData)
        {
            var returnData = new CategoryReturnData();
            try
            {
                var newCategory = new Category
                {
                    TenCategory = requestData.TenCategory,
                    Picture = requestData.Picture
                };

                await _eBookDbContext.Category.AddAsync(newCategory);
                await _eBookDbContext.SaveChangesAsync();

                returnData.ReturnCode = (int)EBook.Common.Enum_ReturnCode.Success;
                returnData.ReturnMsg = "Thêm danh mục thành công";
                returnData.CategoryId = newCategory.CategoryId;
            }
            catch (Exception ex)
            {
                returnData.ReturnCode = (int)EBook.Common.Enum_ReturnCode.Error;
                returnData.ReturnMsg = $"Đã xảy ra lỗi: {ex.Message}";
            }
            return returnData;
        }

        public async Task<CategoryReturnData> UpdateCategoryAsync(CategoryRequestData requestData)
        {
            var returnData = new CategoryReturnData();
            try
            {
                var existingCategory = await _eBookDbContext.Category.FirstOrDefaultAsync(c => c.CategoryId == requestData.CategoryId);
                if (existingCategory == null)
                {
                    returnData.ReturnCode = (int)EBook.Common.Enum_ReturnCode.DataIsNull;
                    returnData.ReturnMsg = "Danh mục không tồn tại";
                    return returnData;
                }

                existingCategory.TenCategory = requestData.TenCategory;
                existingCategory.Picture = requestData.Picture;

                _eBookDbContext.Category.Update(existingCategory);
                await _eBookDbContext.SaveChangesAsync();

                returnData.ReturnCode = (int)EBook.Common.Enum_ReturnCode.Success;
                returnData.ReturnMsg = "Cập nhật danh mục thành công";
            }
            catch (Exception ex)
            {
                returnData.ReturnCode = (int)EBook.Common.Enum_ReturnCode.Error;
                returnData.ReturnMsg = $"Đã xảy ra lỗi: {ex.Message}";
            }
            return returnData;
        }

        public async Task<CategoryReturnData> DeleteCategoryAsync(int categoryId)
        {
            var returnData = new CategoryReturnData();
            try
            {
                var existingCategory = await _eBookDbContext.Category.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
                if (existingCategory == null)
                {
                    returnData.ReturnCode = (int)EBook.Common.Enum_ReturnCode.DataIsNull;
                    returnData.ReturnMsg = "Danh mục không tồn tại";
                    return returnData;
                }

                _eBookDbContext.Category.Remove(existingCategory);
                await _eBookDbContext.SaveChangesAsync();

                returnData.ReturnCode = (int)EBook.Common.Enum_ReturnCode.Success;
                returnData.ReturnMsg = "Xóa danh mục thành công";
            }
            catch (Exception ex)
            {
                returnData.ReturnCode = (int)EBook.Common.Enum_ReturnCode.Error;
                returnData.ReturnMsg = $"Đã xảy ra lỗi: {ex.Message}";
            }
            return returnData;
        }
    }
}
