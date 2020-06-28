using HtmlAgilityPack;
using Neoxam.Domain.Entities;
using Neoxam.Service.IServices;
using Neoxam.Service.Services;
using Newtonsoft.Json;
using Rotativa;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Neoxam.Controllers
{
    public class ReclamationController : Controller
    {
        IReclamationService reclamationService;
        IEmployeeService employeeService;

        public ReclamationController()
        {
            reclamationService = new ReclamationService();
            employeeService = new EmployeeService();
        }
        // GET: Reclamation
        public ActionResult Index()
        {
            var ListFilms = new List<reclamation>();
            var listFilmsDomain = reclamationService.GetMany();


            foreach (reclamation r in listFilmsDomain)

                ListFilms.Add(new reclamation()
                {
                    id = r.id,
                    title = r.title,
                    description = r.description,
                    category = r.category

                });

            ViewBag.res = ListFilms;
            return View();
        }

        public ActionResult updateReclamation(int id)
        {

            reclamation r1 = reclamationService.GetById(id);

            return View(r1);
        }


        public ActionResult archiveReclamation(int id)
        {

            reclamation r1 = reclamationService.GetById(id);
            r1.archivable = true;
            reclamationService.Update(r1);
            reclamationService.Commit();


            return RedirectToAction("boxReclamation");

        }










        public ActionResult DeArchiveReclamation(int id)
        {

            reclamation r1 = reclamationService.GetById(id);
            r1.archivable = false;
            reclamationService.Update(r1);
            reclamationService.Commit();


            return RedirectToAction("boxReclamation");

        }



        [HttpPost]
        public ActionResult updateReclamation(reclamation rec, HttpPostedFileBase file)
        {
            var fileName = "";
            string pathFile;
            if (file != null)
            {
                fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/Upload/ReclamationFolder"), file.FileName);
                file.SaveAs(path);

                pathFile = file.FileName;

            }
            else
            {
                pathFile = "";
            }

            reclamation r1 = reclamationService.GetById(rec.id);
            r1.id = rec.id;
            r1.title = rec.title;
            r1.description = rec.description;
            r1.path_file = pathFile;
            reclamationService.Update(r1);
            reclamationService.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult deleteRec(int id)
        {
            reclamation findet = reclamationService.GetById(id);

            reclamationService.Delete(findet);
            reclamationService.Commit();
            return RedirectToAction("boxReclamation");


        }




        [HttpPost]
        public ActionResult Create(reclamation newrec, HttpPostedFileBase file)
        {
            var fileName = "";
            string pathFile;
            if (file != null)
            {
                fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/Upload/ReclamationFolder"), file.FileName);
                file.SaveAs(path);

                pathFile = file.FileName;

            }
            else
            {
                pathFile = "";
            }

            reclamation rec = new reclamation();
            rec.path_file = pathFile;
            rec.title = newrec.title;
            rec.description = newrec.description;
            rec.category = newrec.category;
            rec.status = 0;
            rec.archivable = false;
            rec.readableRec = "novue";

            rec.employe_Id = 7;
            rec.dateReclamation = DateTime.Now;
            reclamationService.Add(rec);

            reclamationService.Commit();
            return Redirect("http://localhost:9223/VueGlobal/Index");

           // return RedirectToAction("boxReclamation");

        }


        public ActionResult Create()
        {

            return View();
        }
        public string getRec(string searchRec)
        {

            var ListFilms = new List<reclamation>();
            var listFilmsDomain = reclamationService.GetMany();


            foreach (reclamation r in listFilmsDomain)

                if (r.title.Contains(searchRec))
                {

                    ListFilms.Add(new reclamation()
                    {
                        id = r.id,
                        title = r.title,
                        readableRec = r.readableRec,
                        archivable = r.archivable,
                        status = r.status,
                        employe_Id = r.employe_Id,
                        dateReclamation = r.dateReclamation,

                        path_file = r.path_file,
                        description = r.description,
                        category = r.category


                    });
                }
            ListFilms.OrderByDescending(i => i);
            ViewBag.res = ListFilms;
            string jsonx = JsonConvert.SerializeObject(ListFilms, Formatting.Indented);
            return jsonx;

            //return Json(ListFilms, JsonRequestBehavior.AllowGet);
        }



        public string getRecByTechnique()
        {

            var ListFilms = new List<reclamation>();
            var listFilmsDomain = reclamationService.GetMany();


            foreach (reclamation r in listFilmsDomain)

                if (r.category.Equals(Category.Technique))
                {

                    ListFilms.Add(new reclamation()
                    {
                        id = r.id,
                        title = r.title,
                        status = r.status,
                        path_file = r.path_file,
                        description = r.description,
                        category = r.category,
                        employe_Id = r.employe_Id,
                        dateReclamation = r.dateReclamation,

                        readableRec = r.readableRec,
                        archivable = r.archivable


                    });
                }


            ViewBag.res = ListFilms;


            string jsonx = JsonConvert.SerializeObject(ListFilms, Formatting.Indented);
            return jsonx;
            //return Json(ListFilms, JsonRequestBehavior.AllowGet);

        }



        public string getRecByFin()
        {

            var ListFilms = new List<reclamation>();
            var listFilmsDomain = reclamationService.GetMany();


            foreach (reclamation r in listFilmsDomain)

                if (r.category.Equals(Category.Financiére))
                {

                    ListFilms.Add(new reclamation()
                    {
                        id = r.id,
                        title = r.title,
                        status = r.status,
                        readableRec = r.readableRec,
                        archivable = r.archivable,
                        dateReclamation = r.dateReclamation,

                        employe_Id = r.employe_Id,

                        path_file = r.path_file,
                        description = r.description,
                        category = r.category


                    });
                }


            ViewBag.res = ListFilms;

            string jsonx = JsonConvert.SerializeObject(ListFilms, Formatting.Indented);
            return jsonx;
        }


        public string getArchRec()
        {

            var ListFilms = new List<reclamation>();
            var listFilmsDomain = reclamationService.GetMany();


            foreach (reclamation r in listFilmsDomain)
                if (r.archivable == true)

                {

                    ListFilms.Add(new reclamation()
                    {
                        id = r.id,
                        title = r.title,
                        status = r.status,
                        readableRec = r.readableRec,
                        employe_Id = r.employe_Id,
                        dateReclamation = r.dateReclamation,

                        archivable = r.archivable,
                        path_file = r.path_file,
                        description = r.description,
                        category = r.category


                    });
                }


            ViewBag.res = ListFilms;
            string jsonx = JsonConvert.SerializeObject(ListFilms, Formatting.Indented);
            return jsonx;

        }


        public string getAllhRec()
        {

            var ListFilms = new List<reclamation>();
            var listFilmsDomain = reclamationService.GetMany();


            foreach (reclamation r in listFilmsDomain)


                ListFilms.Add(new reclamation()
                {
                    id = r.id,
                    title = r.title,
                    status = r.status,
                    archivable = r.archivable,
                    employe_Id = r.employe_Id,
                    dateReclamation = r.dateReclamation,

                    readableRec = r.readableRec,
                    path_file = r.path_file,
                    description = r.description,
                    category = r.category


                });



            var ListEmployee = new List<user>();
            var listEmployeeDomain = employeeService.GetMany();


            foreach (user r in listEmployeeDomain)



                ListEmployee.Add(new user()
                {
                    id = r.id,
                    first_name = r.first_name,
                    last_name = r.last_name,
                    mail_address = r.mail_address,
                    phone_number = r.phone_number,
                    path_image = r.path_image


                });

            ViewBag.employee = ListEmployee;



            ViewBag.res = ListFilms;
            string jsonx = JsonConvert.SerializeObject(ListFilms, Formatting.Indented);
            return jsonx;
            //return Json(ListFilms, JsonRequestBehavior.AllowGet);
        }


        public string getAllNoRec()
        {

            var ListFilms = new List<reclamation>();
            var listFilmsDomain = reclamationService.GetMany();


            foreach (reclamation r in listFilmsDomain)


                if (r.archivable == false)
                {
                    ListFilms.Add(new reclamation()
                    {
                        id = r.id,
                        title = r.title,
                        status = r.status,
                        readableRec = r.readableRec,
                        archivable = r.archivable,
                        employe_Id = r.employe_Id,
                        dateReclamation = r.dateReclamation,

                        path_file = r.path_file,
                        description = r.description,
                        category = r.category


                    });
                }



            ViewBag.res = ListFilms;
            string jsonx = JsonConvert.SerializeObject(ListFilms, Formatting.Indented);
            return jsonx;
            //return Json(ListFilms, JsonRequestBehavior.AllowGet);
        }




        public string getRecByAutres()
        {

            var ListFilms = new List<reclamation>();
            var listFilmsDomain = reclamationService.GetMany();


            foreach (reclamation r in listFilmsDomain)

                if (r.category.Equals(Category.Autre))
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
                        dateReclamation = r.dateReclamation,


                        description = r.description,
                        category = r.category


                    });
                }


            ViewBag.res = ListFilms;
            string jsonx = JsonConvert.SerializeObject(ListFilms, Formatting.Indented);
            return jsonx;
            //return Json(ListFilms, JsonRequestBehavior.AllowGet);
        }




        public int newNotif()
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
            //return Json(ListFilms, JsonRequestBehavior.AllowGet);
        }




        public ActionResult chartRec()
        {

            var ListFilms = new List<reclamation>();
            var listFilmsDomain = reclamationService.GetMany();
            foreach (reclamation r in listFilmsDomain)

                ListFilms.Add(new reclamation()
                {
                    id = r.id,
                    title = r.title,
                    description = r.description,
                    category = r.category

                });


            List<reclamation> list2 = ListFilms;

            var ages = list2.Select(x => x.category.ToString()).Distinct();
            List<int> repartitions = new List<int>();

            foreach (var item in ages)
            {
                repartitions.Add(list2.Count(x => x.category.ToString() == item));
            }

            var rep = repartitions;
            ViewBag.AGES = ages;



            ViewBag.AGES2 = ages2;

            ViewBag.REP = repartitions.ToList();
            return View();


        }




        public ActionResult chartRecStatus()
        {

            var ListFilms = new List<reclamation>();
            var listFilmsDomain = reclamationService.GetMany();
            foreach (reclamation r in listFilmsDomain)

                ListFilms.Add(new reclamation()
                {
                    id = r.id,
                    title = r.title,
                    status = r.status,
                    description = r.description,
                    category = r.category

                });


            List<reclamation> list2 = ListFilms;

            var ages = list2.Select(x => x.status.ToString()).Distinct();
            List<int> repartitions = new List<int>();

            foreach (var item in ages)
            {
                repartitions.Add(list2.Count(x => x.status.ToString() == item));
            }

            var rep = repartitions;
            ViewBag.AGES = ages;



            ViewBag.AGES2 = ages2;

            ViewBag.REP = repartitions.ToList();
            return View();


        }


        List<user> listEE = new List<user>();


        public ActionResult chartReclamationByEmploye()
        {

            var ListReclamation = new List<reclamation>();
            var ListEmployee = new List<user>();
            //*******************************************//
            var ListReclamationDomain = reclamationService.GetMany();
            var ListEmployeeDomain = employeeService.GetMany();
            //***********************************************//
            foreach (user r in ListEmployeeDomain)

                ListEmployee.Add(new user()
                {
                    id = r.id,
                    first_name = r.first_name,
                    last_name = r.last_name

                });

            List<user> list2E = ListEmployee;

            foreach (reclamation r in ListReclamationDomain)

                ListReclamation.Add(new reclamation()
                {
                    id = r.id,
                    title = r.title,
                    employe_Id = r.employe_Id,
                    description = r.description,
                    category = r.category

                });


            List<reclamation> listReclamation = ListReclamation;
            //****------------------------------------------------*******************

            List<user> listEmployee = list2E;
            //System.Diagnostics.Debug.WriteLine("");
            // var list = employeeService.GetMany();
            // liste qui retourne des repartitions (par métier)
            List<int> repartitions = new List<int>();
            List<string> repartitions2 = new List<string>();
            //selectionner distinct métier $$ages
            foreach (var x in ListEmployeeDomain)
            {
                listEE.Add(new user()
                {
                    first_name = x.first_name,
                    last_name = x.last_name,
                    id = x.id



                });
            }


            var ages = listReclamation.Select(x => x.employe_Id).Distinct();
            //[7,7,5,2]
            var names = listEE.Select(x => x.first_name).Distinct();


            foreach (var item in ages)
            {
                repartitions.Add(listReclamation.Count(x => x.employe_Id == item));
            }

            var rep = repartitions;
            ViewBag.AGES = ages;

            
            foreach (var r0 in listEE)
            {

                foreach (var r in ViewBag.AGES)
                {
                    if (r == r0.id)
                    {
                        ages2 = listEE.Select(x => x.first_name);


                    }
                }
            }
            
            ViewBag.AGES2 = ages2;

            ViewBag.REP = repartitions.ToList();
            return View();


        }





        private IEnumerable<string> ages2T;
        private IEnumerable<string> ages2;
        public ActionResult GetSamples()
        {
            var ListFilms = new List<reclamation>();
            var listFilmsDomain = reclamationService.GetMany();


            foreach (reclamation r in listFilmsDomain)

                ListFilms.Add(new reclamation()
                {
                    id = r.id,
                    title = r.title,
                    description = r.description,
                    category = r.category

                });

            ViewBag.res = ListFilms;
            return View(ListFilms);

        }
        public ActionResult DownloadViewPDF()
        {
            //Code to get content
            //Code to get content
            string dir = "~/Views/Reclamation/";
            string ext = ".cshtml";
            return new Rotativa.PartialViewAsPdf(dir + "GetSamples" + ext) { FileName = "partialViewAsPdf.pdf" };


        }

        public IList<reclamation> GetReclamationList()
        {
            var ListFilms = new List<reclamation>();
            var listFilmsDomain = reclamationService.GetMany();


            foreach (reclamation r in listFilmsDomain)

                ListFilms.Add(new reclamation()
                {
                    id = r.id,
                    title = r.title,
                    dateReclamation = r.dateReclamation,

                    description = r.description,
                    category = r.category

                });
            return ListFilms;
        }
        public ActionResult Index2()
        {
            return View(this.GetReclamationList());
        }

        public ActionResult ExportToExcel()
        {
            var gv = new GridView();
            gv.DataSource = this.GetReclamationList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("Index2");
        }


        public ActionResult Archive2Reclamation()
        {
            var ListReclamation = new List<reclamation>();
            var listReclamationDomain = reclamationService.GetMany();


            foreach (reclamation r in listReclamationDomain)


                if (r.archivable == true)
                {

                    ListReclamation.Add(new reclamation()
                    {
                        id = r.id,
                        title = r.title,
                        description = r.description,
                        status = r.status,
                        readableRec = r.readableRec,
                        archivable = r.archivable,
                        category = r.category

                    });

                }


            ViewBag.res = ListReclamation;



            return View();
        }


        public static bool OnPreRequest2(HttpWebRequest request)
        {
            var cookies = "li_at={YOURCOOKIEHERE};" +
                            "_lipt={YOURCOOKIEHERE}";
            request.Headers.Add(@"cookie:" + cookies);
            return true;
        }






        public ActionResult boxReclamation()
        {
            var ListReclamation = new List<reclamation>();
            var listReclamationDomain = reclamationService.GetMany();

            var ListEmployee = new List<user>();
            var listEmployeeDomain = employeeService.GetMany();


            foreach (user r in listEmployeeDomain)



                ListEmployee.Add(new user()
                {
                    id = r.id,
                    first_name = r.first_name,
                    last_name = r.last_name,
                    mail_address = r.mail_address,
                    phone_number = r.phone_number,
                    path_image = r.path_image


                });

            ViewBag.employee = ListEmployee;




            foreach (reclamation r in listReclamationDomain)



                ListReclamation.Add(new reclamation()
                {
                    id = r.id,
                    title = r.title,
                    description = r.description,
                    dateReclamation = r.dateReclamation,
                    status = r.status,
                    employe_Id = r.employe_Id,
                    readableRec = r.readableRec,
                    archivable = r.archivable,
                    category = r.category

                });

            ListReclamation.OrderBy(w => w.dateReclamation);



            ViewBag.res = ListReclamation;
            ViewBag.all = countAllRec();
            ViewBag.non = countNonRec();
            ViewBag.oui = countOuiRec();












            return View();
        }

        int x;
        int x2;
        int x3;
        public int countAllRec()
        {

            var ListReclamation = new List<reclamation>();
            var listReclamationDomain = reclamationService.GetMany();


            foreach (reclamation r in listReclamationDomain)



                ListReclamation.Add(new reclamation()
                {
                    id = r.id,
                    title = r.title,
                    description = r.description,
                    status = r.status,
                    readableRec = r.readableRec,
                    archivable = r.archivable,
                    category = r.category

                });
            x = ListReclamation.Count();
            return x;
        }

        public int countNonRec()
        {

            var ListReclamation = new List<reclamation>();
            var listReclamationDomain = reclamationService.GetMany();


            foreach (reclamation r in listReclamationDomain)


                if (r.archivable == true)
                {
                    ListReclamation.Add(new reclamation()
                    {
                        id = r.id,
                        title = r.title,
                        description = r.description,
                        status = r.status,
                        readableRec = r.readableRec,
                        archivable = r.archivable,
                        category = r.category

                    });
                }
            x2 = ListReclamation.Count();
            return x2;
        }

        public int countOuiRec()
        {

            var ListReclamation = new List<reclamation>();
            var listReclamationDomain = reclamationService.GetMany();


            foreach (reclamation r in listReclamationDomain)


                if (r.archivable == false)
                {
                    ListReclamation.Add(new reclamation()
                    {
                        id = r.id,
                        title = r.title,
                        description = r.description,
                        status = r.status,
                        readableRec = r.readableRec,
                        archivable = r.archivable,
                        category = r.category

                    });
                }
            x3 = ListReclamation.Count();
            return x3;
        }



        public ActionResult Details(int id)
        {
            reclamation r1 = reclamationService.GetById(id);
            user e1 = employeeService.GetById((long)r1.employe_Id);

            r1.readableRec = "yesvue";
            reclamationService.Update(r1);
            reclamationService.Commit();

            ViewBag.res = r1;
            ViewBag.employeeSelected = e1;

            var ListReclamation = new List<reclamation>();
            var listReclamationDomain = reclamationService.GetMany();

            foreach (reclamation r in listReclamationDomain)



                if (r.employe_Id == e1.id)
                {


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
                }
            ViewBag.countPerso = ListReclamation.Count();


            return View();

        }

        [HttpGet]
        public ActionResult SendEmail(int id, string subjectString, string subjectBody)
        {
            string strsubject = subjectString;


            string strbody = subjectBody;
            SendSMS.Send("Votre reclamation a éte traitée avec success", "+21690312037");


            try
            {


                MailMessage mail = new MailMessage("esprit.4gl1@gmail.com", "esprit.4gl1@gmail.com", strsubject, strbody);
                // MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient("Smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;

                smtpClient.Credentials = new System.Net.NetworkCredential("esprit.4gl1@gmail.com", "Seif1234");
                smtpClient.Send(mail);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            reclamation r1 = new reclamation();
            r1 = reclamationService.GetById(id);

            r1.status = (StatusS)StatusS.CLOTURE;
            reclamationService.Update(r1);
            reclamationService.Commit();

            return RedirectToAction("boxReclamation");
        }


        public class Rootobject
        {
            public Included[] included { get; set; }
        }


        public class Included
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string occupation { get; set; }
            public string objectUrn { get; set; }
            public string publicIdentifier { get; set; }
        }

        public ActionResult Chat()
        {
            return View();
        }



    }
}