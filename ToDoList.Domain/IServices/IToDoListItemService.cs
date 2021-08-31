using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.IServices.Communication;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.IServices
{
    public interface IToDoListItemService
    {
        Task<IEnumerable<ToDoListItem>> ListAsync();
        Task<ToDoListItem> FindByIdAsync(long id);
        Task<ToDoListItemResponse> SaveAsync(ToDoListItem toDoListItem);
        Task<ToDoListItemResponse> UpdateAsync(long id, ToDoListItem toDoListItem);
        Task<ToDoListItemResponse> DeleteAsync(long id);
    }
}
