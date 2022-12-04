using HospitalV2.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalV2.Data.Concretes
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly HospitalManagementDbContext context;


        public UnitOfWork(HospitalManagementDbContext dbContext)
        {
            this.context = dbContext;

        }

        public void Save()
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp);
                    //Log Exception Handling message
                    dbContextTransaction.Rollback();
                }
            }
        }

        public void Rollback()
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                dbContextTransaction.Rollback();
            }
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
