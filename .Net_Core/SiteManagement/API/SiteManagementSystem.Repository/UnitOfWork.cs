using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Repository
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public int Commit()
        {
            return context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return context.SaveChangesAsync();
        }
        private IDbContextTransaction? _transaction;

        //begin transaction method
        public void BeginTransaction()
        {
            _transaction = context.Database.BeginTransaction();
        }

        public Task? TransactionCommitAsync()
        {
            return _transaction?.CommitAsync();
        }

        public Task? TransactionRollbackAsync()
        {
            return _transaction?.RollbackAsync();
        }
    }
}
