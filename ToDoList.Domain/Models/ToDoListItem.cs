using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Models
{
    public class ToDoListItem
    {
        public long ToDoListItemID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
