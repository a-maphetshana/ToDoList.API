using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DTO
{
    public class ErrorResource
    {
        public bool Success => false;
        public List<string> Messages { get; private set; }

        public ErrorResource(List<string> messages)
        {
            Messages = messages ?? new List<string>();
        }

        public ErrorResource(string message)
        {
            this.Messages = new List<string>();

            if (!string.IsNullOrWhiteSpace(message))
            {
                this.Messages.Add(message);
            }
        }
    }
}
