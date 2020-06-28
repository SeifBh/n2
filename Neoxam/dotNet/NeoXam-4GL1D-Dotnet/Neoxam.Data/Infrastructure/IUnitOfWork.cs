
using Solution.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Infrastructures
{
    public interface IUnitOfWork
    {
        void Commit();
        void Dispose();
        IRepositoryBase<T> GetRepositoryBase<T>() where T : class;
    }
}
