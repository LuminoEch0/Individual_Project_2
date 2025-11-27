using DataAccessLayer.DataTransferObjects;
using Individual_Project_2.Models;
using System.Linq;

namespace Individual_Project_2.Mappers
{
    public class CategoryMapper
    {
        public static CategoryModel ToModel(CategoryDTO dto)
        {
            return new CategoryModel(
                dto.CategoryID,
                dto.AccountID,
                dto.CategoryName,
                dto.AllocatedAmount,
                dto.AmountUsed);
        }
        public static List<CategoryModel> ToModelList(IEnumerable<CategoryDTO> dtos)
        {
            return dtos.Select(ToModel).ToList();
        }
        public static CategoryDTO ToDTO(CategoryModel model)
        {
            return new CategoryDTO
            {
                CategoryID = model.AccountID,
                AccountID = model.AccountID,
                CategoryName = model.CategoryName,
                AllocatedAmount = model.AllocatedAmount,
                AmountUsed = model.AmountUsed
            };
        }
    }
}
