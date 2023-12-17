using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPAWeb.DAL.Infrastructure.Interfaces
{
    public interface IUnitOfWork<TContext>
    {
        IRepository<TModel> GetRepository<TModel>() where TModel : class;
        int Commit();
        Task CommitAsync();
    }
}
