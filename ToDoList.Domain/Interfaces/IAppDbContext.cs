using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Interfaces
{
    public interface IAppDbContext
    {
        public IDbConnection Connection { get; }
        DatabaseFacade Database { get; }
        public DbSet<ToDoListItem> ToDoListItem { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
