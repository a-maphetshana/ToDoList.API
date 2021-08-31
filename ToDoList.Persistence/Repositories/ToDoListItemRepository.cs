using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.IRepositories;
using ToDoList.Domain.Models;
using ToDoList.Persistence.Contexts;

namespace ToDoList.Persistence.Repositories
{
    public class ToDoListItemRepository : BaseRepository, IToDoListItemRepository
    {
        private IAppReadDbConnection _readDbConnection { get; }
        public IAppWriteDbConnection _writeDbConnection { get; }
        public ToDoListItemRepository(AppDbContext context, IAppReadDbConnection readDbConnection, IAppWriteDbConnection writeDbConnection) : base(context)
        {
            _readDbConnection = readDbConnection;
            _writeDbConnection = writeDbConnection;
        }

        public async Task<IEnumerable<ToDoListItem>> ListAsync()
        {
            return await Task.FromResult(_context.ToDoListItem.Where(x => !x.IsDeleted).ToList());
        }

        public async Task AddAsync(ToDoListItem toDoListItem)
        {
            await _context.ToDoListItem.AddAsync(toDoListItem);
        }

        public async Task<ToDoListItem> FindByIdAsync(long id)
        {
            return await _context.ToDoListItem.FindAsync(id);
        }

        public void Update(ToDoListItem toDoListItem)
        {
            _context.ToDoListItem.Update(toDoListItem);
        }

        public void Archive(ToDoListItem toDoListItem)
        {
            toDoListItem.IsDeleted = true;
            Update(toDoListItem);
        }

        public void Restore(ToDoListItem toDoListItem)
        {
            toDoListItem.IsDeleted = false;
            Update(toDoListItem);
        }

        public void Delete(ToDoListItem toDoListItem)
        {
            _context.ToDoListItem.Remove(toDoListItem);
        }
    }
}
