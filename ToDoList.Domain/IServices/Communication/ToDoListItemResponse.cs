using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.IServices.Communication
{
    public class ToDoListItemResponse : BaseResponse<ToDoListItem>
    {
        public ToDoListItemResponse(ToDoListItem resource) : base(resource)
        {
        }

        public ToDoListItemResponse(string message) : base(message)
        {
        }
    }
}
