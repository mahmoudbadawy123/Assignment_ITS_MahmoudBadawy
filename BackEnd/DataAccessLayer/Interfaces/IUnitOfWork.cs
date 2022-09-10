using Microsoft.EntityFrameworkCore.Infrastructure;
using Models.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        DatabaseFacade GetDatabase();

       IRepository<Customer> CustomerRepository { get; }

    }

}