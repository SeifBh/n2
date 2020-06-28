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
    public class CandidateSheetController : Controller
    {
        // GET: CandidateSheet
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("rest/fiches_candidats").Result;
            if (response.IsSuccessStatusCode)
                ViewBag.fiches = response.Content.ReadAsAsync<IEnumerable<Candidate_sheet>>().Result;
            else
                ViewBag.fiches = "Erreur affichage liste !";
            return View();
        }

        // GET: CandidateSheet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CandidateSheet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CandidateSheet/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CandidateSheet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CandidateSheet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CandidateSheet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CandidateSheet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
