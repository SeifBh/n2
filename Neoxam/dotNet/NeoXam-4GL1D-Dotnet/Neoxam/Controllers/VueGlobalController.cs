using Neoxam.Domain.Entities;
using Neoxam.Service.IServices;
using Neoxam.Service.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Neoxam.Controllers
{
    public class VueGlobalController : Controller
    {
        IReclamationService reclamationService;
        IEmployeeService employeeService;
        IJobService jobService;
        IDepartmentService depService;
        INon_Attendance non_attendanceService;


        public VueGlobalController()
        {
            reclamationService = new ReclamationService();
            employeeService = new EmployeeService();
            jobService = new JobService();
            depService = new DepartmentService();
            non_attendanceService = new Nont_AttendanceService();

        }

        int totalDep;
        int totalJob;
        int totalEmployee;
        int totalReclamation;
        // GET: VueGlobal
        private IEnumerable<string> ages2_mois;
        private IEnumerable<string> ages22;

        public ActionResult Index()
        {




            ViewBag.totalDep = countAllDep();
            ViewBag.totalJob = countAllJob();
            ViewBag.totalEmployee = countAllEmployee();
            ViewBag.totalReclamation = countAllReclamation();

            ViewBag.NBrecTechnique = countRecTechnique();
            ViewBag.NBrecFin = countRecFinancienere();
            ViewBag.NBrecAutres = countRecAutres();










            var ListEmployee = new List<user>();
            var ListReclamation = new List<reclamation>();
            var ListEmployeeDomain = employeeService.GetMany();
            var ListReclamationDomain = reclamationService.GetMany();



            foreach (reclamation r in ListReclamationDomain)



                ListReclamation.Add(new reclamation()
                {
                    id = r.id,
                    title = r.title,
                    description = r.description,
                    status = r.status,
                    employe_Id = r.employe_Id,
                    readableRec = r.readableRec,
                    archivable = r.archivable,
                    category = r.category

                });

            ViewBag.resRec = ListReclamation;


            foreach (user r in ListEmployeeDomain)



                ListEmployee.Add(new user()
                {
                    id = r.id,
                    first_name = r.first_name,
                    last_name = r.last_name,
                    path_image = r.path_image




                });

            ViewBag.resEmp = ListEmployee;
            TestThis();



            em2();
            chartReclamationByEmploye();
            chartRecStatus();
            chartRec();






            return View();
        }



        public void chartRec()
        {

            var ListRecC = new List<reclamation>();
            var ListRecCDomain = reclamationService.GetMany();
            foreach (reclamation r in ListRecCDomain)

                ListRecC.Add(new reclamation()
                {
                    id = r.id,
                    title = r.title,
                    description = r.description,
                    category = r.category

                });



            var agesC = ListRecC.Select(x => x.category.ToString()).Distinct();
            List<int> repartitionsC = new List<int>();

            foreach (var item in agesC)
            {
                repartitionsC.Add(ListRecC.Count(x => x.category.ToString() == item));
            }

            var rep = repartitionsC;
            ViewBag.AGES = agesC;



            ViewBag.AGESC = ages2;

            ViewBag.REPC = repartitionsC.ToList();


        }





        public void chartReclamationByEmploye()
        {

            var ListeReclamation_T = new List<reclamation>();
            var ListEmployee_T = new List<user>();
            //*******************************************//
            var ListeReclamation_TDomain = reclamationService.GetMany();
            var ListeEmployeeTDomain = employeeService.GetMany();
            //***********************************************//
            foreach (user r in ListeEmployeeTDomain)

                ListEmployee_T.Add(new user()
                {
                    id = r.id,
                    first_name = r.first_name,
                    last_name = r.last_name

                });


            foreach (reclamation r in ListeReclamation_TDomain)

                ListeReclamation_T.Add(new reclamation()
                {
                    id = r.id,
                    title = r.title,
                    employe_Id = r.employe_Id,
                    description = r.description,
                    category = r.category

                });


            List<reclamation> listReclamation1 = ListeReclamation_T;
            //****------------------------------------------------*******************
            List<user> listeEmployee1 = ListEmployee_T;
            //System.Diagnostics.Debug.WriteLine("");
            // var list = employeeService.GetMany();
            // liste qui retourne des repartitions (par métier)
            List<int> repartitionsT = new List<int>();
            List<string> repartitions2T = new List<string>();
            //selectionner distinct métier $$ages


            var agesT = listReclamation1.Select(x => x.employe_Id).Distinct();
            //[7,7,5,2]
            var namesT = listeEmployee1.Select(x => x.first_name).Distinct();


            foreach (var item in agesT)
            {
                repartitionsT.Add(listReclamation1.Count(x => x.employe_Id == item));
            }

            ViewBag.AGEST = agesT;


            foreach (var r0 in listeEmployee1)
            {

                foreach (var r in ViewBag.AGEST)
                {
                    if (r == r0.id)
                    {
                        ages2T = listeEmployee1.Select(x => x.first_name);


                    }
                }
            }

            ViewBag.AGES2T = ages2T;

            ViewBag.REPT = repartitionsT.ToList();



        }


        public void chartRecStatus()
        {

            var ListRecStatus = new List<reclamation>();
            var ListRecStatusDomain = reclamationService.GetMany();
            foreach (reclamation r in ListRecStatusDomain)

                ListRecStatus.Add(new reclamation()
                {
                    id = r.id,
                    title = r.title,
                    status = r.status,
                    description = r.description,
                    category = r.category

                });



            var agesRec = ListRecStatus.Select(x => x.status.ToString()).Distinct();
            List<int> repartitionsRec = new List<int>();

            foreach (var item in agesRec)
            {
                repartitionsRec.Add(ListRecStatus.Count(x => x.status.ToString() == item));
            }

            var rep = ListRecStatus;
            ViewBag.AGESREC = agesRec;



            //ViewBag.AGESREC = ages2;

            ViewBag.REPREC = repartitionsRec.ToList();


        }




        public int countAllDep()
        {

            var ListDepartment = new List<department>();
            var ListDepartmentDomain = depService.GetMany();


            foreach (department r in ListDepartmentDomain)



                ListDepartment.Add(new department()
                {
                    id = r.id


                });
            totalDep = ListDepartment.Count();
            return totalDep;
        }
        public int countAllJob()
        {

            var ListJob= new List<job>();
            var ListJobDomain = jobService.GetMany();


            foreach (job r in ListJobDomain)



                ListJob.Add(new job()
                {
                    id = r.id
                    

                });
            totalJob = ListJob.Count();
            return totalJob;
        }



        public int countAllEmployee()
        {

            var ListEmployee = new List<user>();
            var ListEmployeeDomain = employeeService.GetMany();


            foreach (user r in ListEmployeeDomain)



                ListEmployee.Add(new user()
                {
                    id = r.id


                });
            totalEmployee = ListEmployee.Count();
            return totalEmployee;
        }


        public int countAllReclamation()
        {

            var ListReclamation = new List<reclamation>();
            var ListReclamationDomain = reclamationService.GetMany();


            foreach (reclamation r in ListReclamationDomain)



                ListReclamation.Add(new reclamation()
                {
                    id = r.id


                });
            totalReclamation = ListReclamation.Count();
            return totalReclamation;
        }


        public int countRecTechnique()
        {

            var ListReclamation = new List<reclamation>();
            var ListReclamationDomain = reclamationService.GetMany();


            foreach (reclamation r in ListReclamationDomain)

                if (r.category.Equals(Category.Technique))
                    { 
                    ListReclamation.Add(new reclamation()
                    {
                        id = r.id


                    });
        }
            totalReclamation = ListReclamation.Count();
            return totalReclamation;
        }
        public int countRecFinancienere()
        {

            var ListReclamation = new List<reclamation>();
            var ListReclamationDomain = reclamationService.GetMany();


            foreach (reclamation r in ListReclamationDomain)

                if (r.category.Equals(Category.Financiére))
                {
                    ListReclamation.Add(new reclamation()
                    {
                        id = r.id


                    });
                }
            totalReclamation = ListReclamation.Count();
            return totalReclamation;
        }
        public int countRecAutres()
        {

            var ListReclamation = new List<reclamation>();
            var ListReclamationDomain = reclamationService.GetMany();


            foreach (reclamation r in ListReclamationDomain)

                if (r.category.Equals(Category.Autre))
                {
                    ListReclamation.Add(new reclamation()
                    {
                        id = r.id


                    });
                }
            totalReclamation = ListReclamation.Count();
            return totalReclamation;
        }

        List<user> list = new List<user>();
        List<job> listJob = new List<job>();

        List<user> model = new List<user>();
        List<job> list2 = new List<job>();
        List<job> listFinal = new List<job>();
        List<string> rtl = new List<string>();
        private IEnumerable<string> ages2;
        private IEnumerable<string> ages2T;
        private IEnumerable<string> count2;
        private IEnumerable<string> ages3;
        public void TestThis()
        {

            var ListFilms2 = new List<user>();
            var listFilmsDomain2 = employeeService.GetMany();


            var ListJob = new List<job>();
            var ListJobDomain = jobService.GetMany();


            foreach (user r in listFilmsDomain2)

                ListFilms2.Add(new user()
                {
                    first_name = r.first_name,
                    métier_Id = r.métier_Id


                });


            List<user> list2 = ListFilms2;


            List<user> list = ListFilms2;
            //System.Diagnostics.Debug.WriteLine("");
            var newList = new List<user>();
            // var list = employeeService.GetMany();
            // liste qui retourne des repartitions (par métier)
            List<int> repartitions = new List<int>();
            List<string> repartitions2 = new List<string>();
            //selectionner distinct métier $$ages
            foreach (var x in ListJobDomain)
            {
                listJob.Add(new job()
                {
                    name = x.name,
                    id = x.id



                });
            }
            var ages = list.Select(x => x.métier_Id).Distinct();
            var names = listJob.Select(x => x.name).Distinct();
            foreach (var item in ages)
            {
                System.Diagnostics.Debug.Write("====> " + item);
                System.Diagnostics.Debug.Write("\r\n");




                repartitions.Add(list.Count(x => x.métier_Id == item));


            }
            //foreach (var x2 in repartitions){
            //    System.Diagnostics.Debug.Write("====> " + x2);
            //    System.Diagnostics.Debug.Write("\r\n");
            //}
            var rep = repartitions;
            ViewBag.AGES = ages;
            foreach (var r0 in listJob)
            {

                foreach (var r in ViewBag.AGES)
                {
                    if (r == r0.id)
                    {
                        ages2 = listJob.Select(x => x.name).Distinct();


                    }
                }
            }
            ViewBag.AGES2 = ages2;

            ViewBag.REP = repartitions.ToList();


        }


        public void em2()
        {

            var ListNonAttendance = new List<non_attendance>();
            var ListNonAttendanceDomain = non_attendanceService.GetMany();
            var ListEmployee2 = new List<user>();
            var listEmployeeDomain2 = employeeService.GetMany();



            foreach (non_attendance r in ListNonAttendanceDomain)




                ListNonAttendance.Add(new non_attendance()
                {
                    Id = r.Id,
                    Date = r.Date,
                    employe_Id = r.employe_Id,
                    Isjustified = r.Isjustified






                });


            foreach (user r in listEmployeeDomain2)




                ListEmployee2.Add(new user()
                {
                    id = r.id,
                    first_name = r.first_name,
                    last_name = r.last_name,
                    mail_address = r.mail_address,
                    phone_number = r.phone_number,
                    path_image = r.path_image


                });

            ViewBag.employee2 = ListEmployee2;



            List<int> repartitionList = new List<int>();

            List<non_attendance> ListNonAttendance_M = ListNonAttendance;
            List<user> ListEmployee_M = ListEmployee2;
            var todayMotnh = DateTime.Today.Month;

            var countHeures = ListNonAttendance_M.Where(x => ((DateTime)x.Date).Month == todayMotnh).Select(x => x.employe_Id).Distinct();
            //[7,7,5,2]
            var selectNameEmployee = ListEmployee_M.Select(x => x.first_name).Distinct();


            foreach (var item in countHeures)
            {
                repartitionList.Add(10 - ListNonAttendance_M.Count(x => x.employe_Id == item));
            }

            ViewBag.countHeures2 = countHeures;

            foreach (var r0 in ListEmployee_M)
            {

                foreach (var r in ViewBag.countHeures2)
                {
                    if (r == r0.id)
                    {


                        count2 = ListEmployee_M.Select(x => x.first_name);

                    }

                }
            }

            ViewBag.countHeuresFinal = count2;

            ViewBag.REPName = repartitionList.ToList();




        }


    }
}