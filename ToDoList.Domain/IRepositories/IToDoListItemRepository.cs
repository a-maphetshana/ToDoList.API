using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.IRepositories
{
    public interface IToDoListItemRepository
    {
        Task<IEnumerable<ToDoListItem>> ListAsync();
        Task AddAsync(ToDoListItem toDoListItem);
        Task<ToDoListItem> FindByIdAsync(long id);
        void Update(ToDoListItem toDoListItem);
        void Delete(ToDoListItem toDoListItem);
    }
}
