using Service.Pattern;
using Solution.Data.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Neoxam.Domain.Entities;

namespace Neoxam.Service.Services
{
    public class ReclamationService:Service<reclamation>, IReclamationService
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork unitOfWork = new UnitOfWork(Factory);
        public ReclamationService() : base(unitOfWork)
    {
        }

     
    }
}
