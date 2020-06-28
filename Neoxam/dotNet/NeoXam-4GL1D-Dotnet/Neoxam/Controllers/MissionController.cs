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
    public class MissionController : Controller
    {
        IMissionService missionService;

        public MissionController()
        {
            missionService = new MissionService();
        }

        // GET: Mission
        public ActionResult Index(string searchString)
        {
            var ListMission = new List<Mission>();
            var ListMission2 = missionService.GetMany();
            if (!String.IsNullOrEmpty(searchString))
            {
                ListMission2 = missionService.GetMany(m => m.Place.Contains(searchString));
            }

            foreach (mission m in ListMission2)

                ListMission.Add(new Mission()
                {
                    Place = m.Place,
                    Start_date=m.Start_date,
                    End_date=m.End_date
                });


            return View(ListMission);
        }

        // GET: Mission/Details/5
        public ActionResult Details(int id)
        {
            mission m = missionService.GetById(id);
            Mission model = new Mission
            {
                Place = m.Place,
                Start_date = m.Start_date,
                End_date = m.End_date
            };
            return View(model);
        }

        // GET: Mission/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mission/Create
        [HttpPost]
        public ActionResult Create(Mission model)
        {
            mission m = new mission
            {
                Place=model.Place,
                Start_date=model.Start_date,
                End_date=model.End_date
            };
            missionService.Add(m);
            missionService.Commit();

            return RedirectToAction("Index");
        }

        // GET: Mission/Edit/5
        public ActionResult Edit(int id)
        {
            mission m = missionService.GetById(id);
            Mission model = new Mission
            {
                Place = m.Place,
                Start_date = m.Start_date,
                End_date = m.End_date
            };

            return View(model);
        }

        // POST: Mission/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Mission model)
        {
            mission m = missionService.GetById(id);
            m.Place = model.Place;
            m.Start_date = model.Start_date;
            m.End_date = model.End_date;
            missionService.Update(m);
            missionService.Commit();
            return RedirectToAction("Index");
        }

        // GET: Mission/Delete/5
        public ActionResult Delete(int id)
        {
            mission m = missionService.GetById(id);
            Mission model = new Mission
            {
                Place = m.Place,
                Start_date = m.Start_date,
                End_date = m.End_date
            };

            return View(model);
        }

        // POST: Mission/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            mission m = missionService.GetById(id);
            missionService.Delete(m);
            missionService.Commit();
            return RedirectToAction("Index");
        }
    }
}
