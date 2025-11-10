using DataAccessLayer.DataTransferObjects;
using Individual_Project_2.Models;
using System.Linq;

namespace Individual_Project_2.Mappers
{
    public static class BankAccountMapper
    {
        public static BankAccount ToModel(BankAccountDTO dto)
        {
            return new BankAccount(
                dto.AccountID,
                dto.UserID,
                dto.AccountName,
                dto.CurrentBalance);
        }
        public static List<BankAccount> ToModelList(IEnumerable<BankAccountDTO> dtos)
        {
            return dtos.Select(ToModel).ToList();
        }
        public static BankAccountDTO ToDTO(BankAccount model)
        {
            return new BankAccountDTO
            {
                AccountID = model.AccountID,
                UserID = model.UserID,
                AccountName = model.AccountName,
                CurrentBalance = model.CurrentBalance
            };
        }
    }
}
