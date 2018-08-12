using System;

namespace CRP.Domain.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository Repository { get; }

        void CommitChanges();
    }
}
