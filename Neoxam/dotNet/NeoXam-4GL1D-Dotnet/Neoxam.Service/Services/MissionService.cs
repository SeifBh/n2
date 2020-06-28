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
    public class MissionService:Service<mission>,IMissionService
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public MissionService():base(utk)
        {

        }
    }
}
