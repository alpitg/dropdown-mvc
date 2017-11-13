using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcCRUD1.Models;
using MvcCRUD1.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MvcCRUD1.Controllers
{
    public class StudentsController : Controller
    {
        private StudentContext db = new StudentContext();



        /// <summary>
        /// Validation for email 
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public JsonResult JsonEmailValid(string Email)
        {
            var result = true;
            var user = db.Students.Where(x => x.Email == Email).FirstOrDefault();

            if (user != null)
                result = false;

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // GET: Students
        public ActionResult Index()
        {
            StudentViewModel mymodel = new StudentViewModel();

            mymodel.Students = new Student();
            mymodel.StudentList = GetStudents();

            ViewBag.CountryList = db.Countries;
            // ViewBag.StateList = db.States;

            return View(mymodel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //[AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {

                //ModelState.AddModelError(string.Empty, "Email Already Present !");

                var sa= JsonEmailValid(student.Students.Email);

                db.Students.Add(student.Students);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.CountryList = db.Countries;
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Get all Student data
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudents()
        {
            return db.Students.ToList();
        }


        public ActionResult FillState(int country)
        {
            var states = db.States.Where(c => c.CountryId == country);
            return Json(states, JsonRequestBehavior.AllowGet);
        }


        //public ActionResult FillCity(int state)
        //{
        //    var cities = db.Cities.Where(c => c.StateId == state);
        //    return Json(cities, JsonRequestBehavior.AllowGet);
        //}





        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Contact,Address,Country,State,City,PinCode")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Contact,Address,Country,State,City,PinCode")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
