using Domain.Pay.Entities;
using Repository.Pay.Data;
using System;
using System.Threading.Tasks;

namespace Repository.Pay.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected readonly IPaymentDbContext _paymentDbContext;
        protected IRepository<Payment> _paymentRepository;
        protected bool _disposed = false;

        public UnitOfWork(IPaymentDbContext paymentDbContext)
        {
            _paymentDbContext = paymentDbContext;
        }

        public IRepository<Payment> PaymentRepository => _paymentRepository ??= _paymentRepository = new EfRepository<Payment>(_paymentDbContext);

        public void Commit()
        {
            _paymentDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _paymentDbContext.SaveChangesAsync();
        }

        #region IDisposable Members

        /* https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application */
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _paymentDbContext.Dispose();
                }
            }
            _disposed = true;
        }

        #endregion
    }
}
