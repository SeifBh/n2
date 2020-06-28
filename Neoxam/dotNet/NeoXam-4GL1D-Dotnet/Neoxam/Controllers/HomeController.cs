using Neoxam.Domain.Entities;
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
    public class HomeController : Controller
    {
        IReclamationService reclamationService;

        IReclamationService reclamationService2;

        public HomeController()
        {
            reclamationService = new ReclamationService();

            reclamationService2 = new ReclamationService();
        }

        public ActionResult Index()
        {




        //   ViewBag.countAllRec = realnotify();





            return View();
        }


        //public int realnotify()
        //{

        //    var ListRecCount = new List<reclamation>();
        //    var ListRecCountDomain = reclamationService2.GetMany();


        //    foreach (reclamation r in ListRecCountDomain)

        //        if (r.readableRec.Equals("novue"))
        //        {


        //            {

        //                ListRecCount.Add(new reclamation()
        //                {
        //                    id = r.id,
        //                    title = r.title,
        //                    status = r.status,
        //                    path_file = r.path_file,
        //                    readableRec = r.readableRec,
        //                    archivable = r.archivable,
        //                    employe_Id = r.employe_Id,

        //                    description = r.description,
        //                    category = r.category


        //                });
        //            }
        //        }

        //    var x = ListRecCount.Count();
        //    ViewBag.countAllRec = ListRecCount.Count();
        //    return x;
        //    //return Json(ListFilms, JsonRequestBehavior.AllowGet);
        //}

        public int not()
        {
            var ListFilms = new List<reclamation>();
            var listFilmsDomain = reclamationService.GetMany();


            foreach (reclamation r in listFilmsDomain)

                if (r.readableRec.Equals("novue"))
                {


                    {

                        ListFilms.Add(new reclamation()
                        {
                            id = r.id,
                            title = r.title,
                            status = r.status,
                            path_file = r.path_file,
                            readableRec = r.readableRec,
                            archivable = r.archivable,
                            employe_Id = r.employe_Id,

                            description = r.description,
                            category = r.category


                        });
                    }
                }

            var x = ListFilms.Count();
            ViewBag.notifCount = ListFilms.Count();

            return x;
        }



        public ActionResult EmptyPage()
        {
            return View();
        }

        public ActionResult frontPage()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}