using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
   public class UnitOfWork : IDisposable
    {
        private CarShopDbContext context = new CarShopDbContext();
        private GenericRepository<Buyer> buyerRepository;
        private GenericRepository<Sellar> sellarRepository;
        private GenericRepository<CarList> carListRepository;

        public GenericRepository<Sellar> SellarRepository
        {
            get
            {

                if (this.sellarRepository == null)
                {
                    this.sellarRepository = new GenericRepository<Sellar>(context);
                }
                return sellarRepository;
            }
        }
        public GenericRepository<Buyer> BuyerRepository
        {
            get
            {

                if (this.buyerRepository == null)
                {
                    this.buyerRepository = new GenericRepository<Buyer>(context);
                }
                return buyerRepository;
            }
        }

        public GenericRepository<CarList> CarListRepository
        {
            get
            {
                if (this.carListRepository == null)
                {
                    this.carListRepository = new GenericRepository<CarList>(context);
                }
                return carListRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
