using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.BLL.DTO;

namespace NLayer.BLL.Interfaces
{
    public interface ICategoryService
    {
        void MakeCategory(CategoryDTO categoryDTO);
        CategoryDTO GetCategory(int? id);
        IEnumerable<CategoryDTO> GetCategory();
        void Dispose();
    }
}
