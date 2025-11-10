using DataAccessLayer.Repositories;
using Individual_Project_2.Mappers;
using Individual_Project_2.Models;

namespace Individual_Project_2.Services.Dashboard
{
    public class BankAccountService
    {
        private readonly BankAccountRepository _repository;

        public BankAccountService(BankAccountRepository repository)
        {
            _repository = repository;
        }

        public List<BankAccount> GetAllBankAccounts()
        {
            var dtos = _repository.GetBankAccounts();
            return BankAccountMapper.ToModelList(dtos);
        }

        public BankAccount? GetAccountById(Guid id)
        {
            var dto = _repository.GetBankAccountById(id);
            return dto == null ? null : BankAccountMapper.ToModel(dto);
        }

        public void UpdateAccountDetails(BankAccount account)
        {
            var dto = BankAccountMapper.ToDTO(account);
            _repository.UpdateBankAccount(dto);
        }

        public void DeleteAccount(Guid accountId)
        {
            var account = GetAccountById(accountId);
            if (account != null && account.CurrentBalance != 0)
            {
                throw new InvalidOperationException("Cannot delete account with a non-zero balance.");
            }
            _repository.DeleteBankAccount(accountId);
        }
    }
}