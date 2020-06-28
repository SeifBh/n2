using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.Data.Infrastructure;

namespace Solution.Data.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        IDataBaseFactory factory = null;
        public UnitOfWork(IDataBaseFactory factory)
        {
            this.factory = factory;
            
        }
        public void Commit() 
        {   
           
            factory.DataContext.SaveChanges();
        }

        public void Dispose()
        {
            factory.Dispose();
        }

        public IRepositoryBase<T> GetRepositoryBase<T>() where T : class
        {
            return new RepositoryBase<T>(factory.DataContext);
        }
    }
}
