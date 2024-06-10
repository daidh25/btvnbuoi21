using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Book.DTO
{
    public class CategoryReturnData
    {
        public int ReturnCode { get; set; }
        public string ReturnMsg { get; set; }
        public int CategoryId { get; set; }
    }
}
