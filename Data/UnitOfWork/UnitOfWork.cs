using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data.UnitOfWork
{
    public class UnitOfWork<TContext> :IUnitOfWork<TContext> , IDisposable where TContext : DbContext, new()
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction  _objTran;
        private string _errorMessage = string.Empty;
        private bool _disposed;

        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
        }

        public UnitOfWork(DbContextOptions options)
        {
            _context = new ApplicationDbContext(options);
        }

        public ApplicationDbContext Context 
         { 
            get { return _context; }
                
         }

        public void Commit()
        {
            _objTran.Commit();
        }

        public void CreateTransaction()
        {
            _objTran = _context.Database.BeginTransaction();
        }

        public void Rollback()
        {
            _objTran.Rollback();
            _objTran.Dispose();
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                SqlException s = e.InnerException.InnerException as SqlException;
                if (s != null && s.Number == 2627)
                {
                    _errorMessage += string.Format("Part number '{0}' already exists.", s.Number);
                }
                else
                {
                    _errorMessage += string.Format("An error occured - please contact your system administrator.");
                }
                throw;
            }

        }


        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        
    }
}
