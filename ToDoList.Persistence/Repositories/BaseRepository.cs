using ToDoList.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
