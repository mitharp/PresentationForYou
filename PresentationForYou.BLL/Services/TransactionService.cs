using PresentationForYou.BLL.DTO;
using PresentationForYou.BLL.Interfaces;
using PresentationForYou.DAL.Entities;
using PresentationForYou.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationForYou.BLL.Services
{
    public class TransactionService : IService<TransactionDTO>
    {
        IUnitOfWork Database { get; set; }
        public TransactionService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void Add(TransactionDTO transaction)
        {
            Database.Transactions.Create((Transaction)transaction);
            Database.Save();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Edit(TransactionDTO transaction)
        {
            Database.Transactions.Update((Transaction)transaction);
            Database.Save();
        }

        public TransactionDTO Get(int? id)
        {
            if (id == null)
                throw new Exception("Не установлено id телефона");
            var transaction = Database.Transactions.Get(id.Value);
            if (transaction == null)
                throw new Exception("Телефон не найден");
            Mapper.Initialize(item => item.CreateMap<Transaction, TransactionDTO>());
            return Mapper.Map<IEnumerable<Transaction>, List<TransactionDTO>>(transaction)[0];
        }

        public IEnumerable<TransactionDTO> GetAll() =>
            Database.Transactions.GetAll().Select(a => new TransactionDTO
            {
                Account = new AccountDTO { Id = a.Account.Id, Name = a.Account.Name, CurrentState = a.Account.CurrentState, Description = a.Account.Description },
                AccountId = a.AccountId,
                Amount = a.Amount,
                Date = a.Date,
                Source = new SourceDTO { Id = a.Source.Id, Description = a.Source.Description, Name = a.Source.Name },
                SourceId = a.SourceId,
                Description = a.Description
            }).ToList();

        public void Remove(int id)
        {
            Database.Sources.Delete(id);
            Database.Save();
        }

    }
}
