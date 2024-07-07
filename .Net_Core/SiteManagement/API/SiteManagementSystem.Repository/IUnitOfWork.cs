using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Repository
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
        void BeginTransaction();
        Task? TransactionCommitAsync();
        Task? TransactionRollbackAsync();
    }
}
