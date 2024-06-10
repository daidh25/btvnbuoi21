using DataAccess.Book.DTO;
using DataAccess.BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Book.IServices
{
    public interface ICategoryServices
    {
        Task<Category> CategoryGetList(Category category);
        Task<CategoryReturnData> CategoryInsertUpdate(Category category);
    }
}
