using System;
using Fasitec.Business.Unities;

namespace Data.Unities
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context context;
        public UnitOfWork(Context context)
        {
            this.context = context;
        }
        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(context);
        }
    }
}