using DataAccessLayer.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Models.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Class
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _dbContext;
        private readonly IDbContextTransaction Transaction;
        public UnitOfWork(ApplicationContext context)
        {
            _dbContext = context;
        }



        private IRepository<Customer> _CustomerRepository;
        public IRepository<Customer> CustomerRepository => _CustomerRepository ?? (_CustomerRepository = new Repository<Customer>(_dbContext));

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public DatabaseFacade GetDatabase()
        {
            return _dbContext.Database;
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

  
    }
}
