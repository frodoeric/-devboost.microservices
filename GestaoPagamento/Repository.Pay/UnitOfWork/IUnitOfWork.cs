using Domain.Pay.Entities;
using System.Threading.Tasks;

namespace Repository.Pay.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Payment> PaymentRepository { get; }

        void Commit();

        Task CommitAsync();

        void Dispose();
    }
}
