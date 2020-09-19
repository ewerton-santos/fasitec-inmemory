using System;

namespace Fasitec.Business.Unities
{
     public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}