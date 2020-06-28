using Neoxam.Domain.Entities;
using Neoxam.Models;
using Neoxam.Service.IServices;
using Neoxam.Service.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Rotativa;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;



namespace Neoxam.Controllers

{
    public class EmployeeController : Controller
    {
        IEmployeeService employeeService;
        INon_Attendance non_attendanceService;

        public EmployeeController()
        {
            employeeService = new EmployeeService();
            non_attendanceService = new Nont_AttendanceService();
        }



        public JsonResult getStudent(string searchString)
        {

            if (!String.IsNullOrEmpty(searchString))
            {

                HttpClient Client = new HttpClient();
                Client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = Client.GetAsync("rest/employees/search/seif").Result;

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.res = response.Content.ReadAsAsync<IEnumerable<user>>().Result;


                }





            }
            return Json(ViewBag.res, JsonRequestBehavior.AllowGet);
        }

        // GET: Employee
        public ActionResult Index(string searchString)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/employees/").Result;


            if (!String.IsNullOrEmpty(searchString))
            {


                user emp = null;

                HttpClient Client2 = new HttpClient();
                Client2.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
                Client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response2 = Client.GetAsync("rest/employees/" + searchString).Result;


                if (response.IsSuccessStatusCode)
                {
                    ViewBag.res = response2.Content.ReadAsAsync<IEnumerable<user>>().Result;

                    return View(ViewBag.res);
                }
                else
                {

                    ViewBag.res = response.Content.ReadAsAsync<IEnumerable<user>>().Result;


                    return View(ViewBag.res);
                }










            }

            if (response.IsSuccessStatusCode)
            {

                ViewBag.res = response.Content.ReadAsAsync<IEnumerable<user>>().Result;
                //ViewBag.res.hiring_date = new DateTime();
                //string serializedString = Newtonsoft.Json.JsonConvert.SerializeObject(response);

                //ViewBag.res = serializedString;
            }

            else
            {
                ViewBag.res = "error";
            }




            return View();
        }

        public ActionResult findByJob(int idJob)
        {
            user emp = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
                //HTTP GET
                var responseTask = client.GetAsync("rest/metiers/" + idJob);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<user>();
                    readTask.Wait();

                    emp = readTask.Result;
                }
            }

            return View(emp);

        }
        [HttpGet]
        public ActionResult Create()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/metiers/").Result;



            var jobs = response.Content.ReadAsAsync<IEnumerable<job>>().Result;


            ViewBag.myproducer =
                new SelectList(jobs, "id", "name");


            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(user emp, HttpPostedFileBase file, int ddlVendor, FormCollection form)
        {
            string strDDLValue = form["ddlVendor"].ToString();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
                //HTTP POST

                var fileName = "";
                var imageFile = "";
                if (file != null)
                {
                    fileName = Path.GetFileName(file.FileName);

                    var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                    file.SaveAs(path);
                    imageFile = file.FileName;
                    emp.path_image = imageFile;

                }
                else
                {
                    emp.path_image = "";

                }



                var putTask = client.PostAsJsonAsync<user>("rest/employees/" + strDDLValue, emp).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
                putTask.Wait();









                var result0 = putTask.Result;
                if (result0.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }




            //Index();




            return RedirectToAction("Index");

        }
        [HttpPut]
        public ActionResult editMe()
        {


            return View();
        }

        public async Task<ActionResult> testhere(user emp)
        {
            using (var client = new HttpClient())
            {

                HttpResponseMessage response = await client.PutAsJsonAsync("http://localhost:18080/Neoxam4GL1D-web/rest/emp/update/" + emp.id, emp);
                response.EnsureSuccessStatusCode();

                // Deserialize the updated product from the response body.
                emp = await response.Content.ReadAsAsync<user>();


            }
            return View();
        }
        public ActionResult EditEmployee()
        {


            return View();
        }

        public ActionResult UpdateEmployee(int id)
        {

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/metiers/").Result;



            var jobs = response.Content.ReadAsAsync<IEnumerable<job>>().Result;


            ViewBag.myproducer =
                new SelectList(jobs, "id", "name");




            user emp = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
                //HTTP GET
                var responseTask = client.GetAsync("rest/employees/findById/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<user>();
                    readTask.Wait();

                    emp = readTask.Result;
                }
            }

            return View(emp);
        }


        [HttpPost]
        public ActionResult UpdateEmployee(user emp, HttpPostedFileBase file, int ddlVendor, FormCollection form)
        {
            string strDDLValue = form["ddlVendor"].ToString();
            System.Diagnostics.Debug.WriteLine("You click me .................." + strDDLValue);


            var fileName = "";
            var imageFile = "";

            if (file == null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");





                    //HTTP POST
                    var putTask = client.PutAsJsonAsync<user>("rest/employees/" + strDDLValue + "/" + emp.id, emp);
                    putTask.Wait();


                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                }
            }
            else
            {

                fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("/Content/Upload/"), file.FileName);

                emp.path_image = file.FileName;
                file.SaveAs(path);


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");





                    //HTTP POST
                    var putTask = client.PutAsJsonAsync<user>("rest/employees/" + strDDLValue + "/" + emp.id, emp);
                    putTask.Wait();


                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                }


            }

            return View(emp);
        }
        public ActionResult deleteE(int id)
        {
            using (var client2 = new HttpClient())
            {

                client2.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
                var response = client2.DeleteAsync("rest/employees/" + id).Result;
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
        [HttpDelete]
        public ActionResult DeleteEmployee(int id)
        {
            using (var client2 = new HttpClient())
            {

                client2.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
                var response = client2.DeleteAsync("rest/employees/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                }
                else
                    Console.Write("Error");
            }
            //Index();
            return View();
        }
        [HttpDelete]
        public ActionResult Delete()
        {
            //Console.WriteLine("id = " + id);
            /*
            using (var client2 = new HttpClient())
            {

                client2.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
                var response = client2.DeleteAsync("rest/emp/delete/"+id).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                }
                else
                    Console.Write("Error");
            }
            return "ok"; */

            return View();

        }

        public ActionResult monthEmployee()
        {


            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/employees/getMonthEmp").Result;


            if (response.IsSuccessStatusCode)
            {

                var jsonString = response.Content.ReadAsStringAsync();

                ViewBag.res = JsonConvert.DeserializeObject<List<Object>>(jsonString.Result);

            }


            else
            {
                ViewBag.res = "error";
            }


            return View();
        }

        public ActionResult stat2()
        {


            var list = employeeService.GetMany();



            List<int> repartitions = new List<int>();
            var ages = list.Select(x => x.DTYPE.Equals("Employee")).Distinct();

            foreach (var item in ages)
            {
                repartitions.Add(list.Count(x => x.DTYPE.Equals("Employee")));
            }

            var rep = repartitions;
            ViewBag.AGES = ages;
            ViewBag.REP = repartitions.ToList();



            return View();



        }

        public ActionResult DownloadViewPDF()
        {


            var p = new ActionAsPdf("Index");
            return p;
            //Code to get content
       

        }
        private IEnumerable<string> ages2;



        public ActionResult EmployeeduMois()
        {
            var ListNonAttendance = new List<non_attendance>();
            var ListNonAttendanceDomain = non_attendanceService.GetMany();
            var ListEmployee = new List<user>();
            var listEmployeeDomain = employeeService.GetMany();



            foreach (non_attendance r in ListNonAttendanceDomain)




                ListNonAttendance.Add(new non_attendance()
                {
                    Id = r.Id,
                    Date = r.Date,
                    employe_Id = r.employe_Id,
                    Isjustified = r.Isjustified

                  




                });


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



            List<int> repartitions = new List<int>();

            List<non_attendance> list1 = ListNonAttendance;
            List<user> list2 = ListEmployee;
            var todayMotnh = DateTime.Today.Month;

            var ages = list1.OrderBy(x=>x.Id).Where(x=>((DateTime)x.Date).Month == todayMotnh).Select(x=>x.employe_Id).Distinct();
            //[7,7,5,2]
            var names = list2.Select(x => x.first_name).Distinct();


            foreach (var item in ages)
            {
                repartitions.Add(10-list1.Count(x => x.employe_Id == item));
            }

            var rep = repartitions;
            ViewBag.AGES = ages;

            foreach (var r0 in list2)
            {

                foreach (var r in ViewBag.AGES)
                {
                    
                        ages2 = list2.Select(x => x.first_name);


                    
                }
            }

            ViewBag.AGES2 = ages2;
          
            ViewBag.REP = repartitions.ToList();
            return View();

        }
    }
}