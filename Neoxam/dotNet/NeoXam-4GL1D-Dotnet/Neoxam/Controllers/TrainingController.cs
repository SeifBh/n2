using Neoxam.Domain.Entities;
using Neoxam.Models;
using Neoxam.Service.IServices;
using Neoxam.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Neoxam.Controllers
{
    public class TrainingController : Controller
    {
        ITrainingService trainingService;

        public TrainingController()
        {
            trainingService = new TrainingService();
        }

        // GET: Training
        public ActionResult Index(string searchString)
        {
            var ListTrainings = new List<Training>();
            var ListTrainings2 = trainingService.GetMany();
            if (!String.IsNullOrEmpty(searchString))
            {
                ListTrainings2 = trainingService.GetMany(m => m.Place.Contains(searchString));
            }

            foreach (training m in ListTrainings2)

                ListTrainings.Add(new Training()
                {
                    Former=m.Former,
                    Start_date=m.Start_date,
                    End_date=m.End_date,
                    Place=m.Place,
                    Price=m.Price
                });

            return View(ListTrainings);
        }

        // GET: Training/Details/5
        public ActionResult Details(int id)
        {
            training t = trainingService.GetById(id);
            Training model = new Training
            {

                Former = t.Former,
                Start_date = t.Start_date,
                End_date = t.End_date,
                Place = t.Place,
                Price = t.Price
            };

            return View(model);
        }

        // GET: Training/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Training/Create
        [HttpPost]
        public ActionResult Create(Training model)
        {
            training t = new training
            {
               Former=model.Former,
               Start_date=model.Start_date,
               End_date=model.End_date,
               Place=model.Place,
               Price=model.Price
            };

            trainingService.Add(t);
            trainingService.Commit();

            return RedirectToAction("Index");
        }

        // GET: Training/Edit/5
        public ActionResult Edit(int id)
        {
            training t = trainingService.GetById(id);
            Training model = new Training
            {

                Former = t.Former,
                Start_date = t.Start_date,
                End_date = t.End_date,
                Place = t.Place,
                Price = t.Price
            };

            return View(model);
        }

        // POST: Training/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Training model)
        {
            training t = trainingService.GetById(id);
            t.Former = model.Former;
            t.Start_date = model.Start_date;
            t.End_date = model.End_date;
            t.Place = model.Place;
            t.Price = model.Price;
            trainingService.Update(t);
            trainingService.Commit();
            return RedirectToAction("Index");
        }

        // GET: Training/Delete/5
        public ActionResult Delete(int id)
        {
            training t = trainingService.GetById(id);
            Training model = new Training
            {

                Former = t.Former,
                Start_date = t.Start_date,
                End_date = t.End_date,
                Place = t.Place,
                Price = t.Price
            };

            return View(model);
        }

        // POST: Training/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            training t = trainingService.GetById(id);
            trainingService.Delete(t);
            trainingService.Commit();
            return RedirectToAction("Index");
        }
    }
}
