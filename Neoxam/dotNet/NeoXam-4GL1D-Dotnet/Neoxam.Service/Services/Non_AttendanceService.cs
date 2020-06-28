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
    public class Nont_AttendanceService : Service<non_attendance>, INon_Attendance
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public Nont_AttendanceService() : base(utk)
        {

        }
    }

}
