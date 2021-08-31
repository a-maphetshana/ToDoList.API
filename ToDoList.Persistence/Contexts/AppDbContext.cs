using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Models;

namespace ToDoList.Persistence.Contexts
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<ToDoListItem> ToDoListItem { get; set; }
        public IDbConnection Connection => Database.GetDbConnection();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ToDoListItem>().HasKey(t => t.ToDoListItemID);
            builder.Entity<ToDoListItem>().Property(t => t.ToDoListItemID).IsRequired().ValueGeneratedOnAdd();

            builder.Entity<ToDoListItem>().HasData
            (
                new ToDoListItem { ToDoListItemID = 001, Name = "Test Task" }
            );
        }

    }
}
