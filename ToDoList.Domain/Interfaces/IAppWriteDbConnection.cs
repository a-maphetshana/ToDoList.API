using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ToDoList.Domain.Interfaces
{
    public interface IAppWriteDbConnection : IAppReadDbConnection
    {
        Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
    }
}
