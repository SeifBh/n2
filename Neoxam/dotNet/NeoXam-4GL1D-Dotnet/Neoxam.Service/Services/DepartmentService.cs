using Neoxam.Domain.Entities;
using Neoxam.Service.IServices;
using Service.Pattern;
using Solution.Data.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neoxam.Service.Services
{
    public class DepartmentService : Service<department>, IDepartmentService
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public DepartmentService() : base(utk)
        {

        }
    }

}
