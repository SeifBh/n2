using Neoxam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Threading;

namespace Neoxam.Controllers
{
    public class JobController : Controller
    {

        // GET: Job
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/metiers/").Result;



            if (response.IsSuccessStatusCode)
            {
                ViewBag.res = response.Content.ReadAsAsync<IEnumerable<job>>().Result;

            }

            else
            {
                ViewBag.res = "error";
            }

            // ViewBag.Result1 = getDep().Result;

            return View();

        }


        [HttpGet]
        public ActionResult Create()
        {

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/departements/").Result;



            var jobs = response.Content.ReadAsAsync<IEnumerable<department>>().Result;


            ViewBag.mydep =
                new SelectList(jobs, "id", "name");


            return View();
        }

        // POST: Job/Create
        [HttpPost]
        public ActionResult Create(job j,int ddlVendor, FormCollection form)
        {
            string strDDLValue = form["ddlVendor"].ToString();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
                //HTTP POST
                var putTask = client.PostAsJsonAsync<job>("rest/metiers/" + strDDLValue, j).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
                putTask.Wait();
                var result0 = putTask.Result;
                if (result0.IsSuccessStatusCode)
                {            
                    return RedirectToAction("Index");
                }
            }


            return RedirectToAction("Index");

        }


        public ActionResult UpdateJob(int id)
        {


            HttpClient Client2 = new HttpClient();
            Client2.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
            Client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response2 = Client2.GetAsync("rest/departements/").Result;



            var jobs2 = response2.Content.ReadAsAsync<IEnumerable<department>>().Result;


            ViewBag.mydep2 =
                new SelectList(jobs2, "id", "name");


            job j = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
                //HTTP GET
                var responseTask = client.GetAsync("rest/metiers/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<job>();
                    readTask.Wait();

                    j = readTask.Result;
                }
            }

            return View(j);
        }

        [HttpPost]
        public ActionResult UpdateJob(job j, int ddlVendor, FormCollection form)
        {
            string strDDLValue = form["ddlVendor"].ToString();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<job>("rest/metiers/" + strDDLValue+"/" + j.id, j);
                putTask.Wait();


                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(j);
        }




        public ActionResult deleteJob(int id)
        {
            using (var client2 = new HttpClient())
            {

                client2.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
                var response = client2.DeleteAsync("rest/metiers/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                }
                else
                    Console.Write("Error");
            }
            //Index();
            return RedirectToAction("Index");

        }



    }
}