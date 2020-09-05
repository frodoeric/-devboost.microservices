using Domain.Pay.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repository.Pay.Data
{
    public interface IPaymentDbContext
    {
        DbSet<T> Set<T>() where T : Entity;

        int SaveChanges();

        Task<int> SaveChangesAsync();

        void Dispose();
    }
}
