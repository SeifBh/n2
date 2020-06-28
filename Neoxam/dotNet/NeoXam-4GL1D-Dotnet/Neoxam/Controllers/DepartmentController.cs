using Neoxam.Domain.Entities;
using Neoxam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Neoxam.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/departements/").Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.res = response.Content.ReadAsAsync<IEnumerable<Department>>().Result;
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

            if (response.IsSuccessStatusCode)
            {
                ViewBag.res = response.Content.ReadAsAsync<IEnumerable<Department>>().Result;
            }

            else
            {
                ViewBag.res = "error";
            }

            return View();
        }


        [HttpPost]
        public ActionResult Create(department dep)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");

                //HTTP POST
                var putTask = client.PostAsJsonAsync<department>("rest/departements", dep).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
                putTask.Wait();
                var result0 = putTask.Result;
                if (result0.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }


            }


            return RedirectToAction("Index");

        }


        public ActionResult UpdateDep(int id)
        {
            department dep = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
                //HTTP GET
                var responseTask = client.GetAsync("rest/departements/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<department>();
                    readTask.Wait();

                    dep = readTask.Result;
                }
            }

            return View(dep);
        }

        [HttpPost]
        public ActionResult UpdateDep(department dep)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<department>("rest/departements/" + dep.id, dep);
                putTask.Wait();


                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(dep);
        }

        public ActionResult DeleteDep(int id)
        {
            using (var client2 = new HttpClient())
            {

                client2.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
                var response = client2.DeleteAsync("rest/departements/" + id).Result;
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