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
    public class statController : Controller
    {

        IEmployeeService employeeService;
        IJobService jobService;
        IDepartmentService depService;

        public statController()
        {
            employeeService = new EmployeeService();
            jobService = new JobService();
            depService = new DepartmentService();
        }

        List<user> list = new List<user>();
        List<job> listJob = new List<job>();

        List<user> model = new List<user>();
        List<job> list2 = new List<job>();
        List<job> listFinal = new List<job>();
        List<string> rtl = new List<string>();
        private IEnumerable<string> ages2;

        // GET: stat
        public ActionResult Index()
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
            var newList =new List<user>();
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
                    id =x.id
                   


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
            return View();

        }


        public ActionResult chartDep()
        {
           

            var ListJob = new List<job>();
            var ListJobDomain = jobService.GetMany();
            var ListDep = new List<department>();
            var ListDepDomain = depService.GetMany();

            foreach (department r in ListDepDomain)

                ListDep.Add(new department()
                {
                    id = r.id,
                    name = r.name

                });

            List<department> list2E = ListDep;


            foreach (job r in ListJobDomain)

                ListJob.Add(new job()
                {
                    name = r.name,
                    département_Id = r.département_Id


                });


            List<job> list2 = ListJob;


            //System.Diagnostics.Debug.WriteLine("");
            var newList = new List<user>();
            // var list = employeeService.GetMany();
            // liste qui retourne des repartitions (par métier)
            List<int> repartitions = new List<int>();
            //selectionner distinct métier $$ages
            var ages = list2.Select(x => x.département_Id).Distinct();
            var names = list2E.Select(x => x.name).Distinct();

            var listNomDep = new List<department>();
         
            foreach (var item in ages)
            {
                repartitions.Add(list2.Count(x => x.département_Id == item));
            }
            var rep = repartitions;
            ViewBag.AGES = ages;

            foreach (var r0 in list2E)
            {

                foreach (var r in ViewBag.AGES)
                {
                    if (r == r0.id)
                    {
                        ages2 = list2E.Select(x => x.name);


                    }
                }
            }
            ViewBag.AGES2 = ages2;

            ViewBag.REP = repartitions.ToList();
            return View();
        }
    }
}