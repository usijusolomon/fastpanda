using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataBase.DataContext;
using ObjectClass.Encryption;
using ObjectClass.Enums;
using ObjectClass.Objects;

namespace Tea.Controllers.UserManagement
{
    public class UsersController : Controller
    {
        private UserDataBaseConnection db = new UserDataBaseConnection();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Department).Include(u => u.Faculty).Include(u => u.Level);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "Name");
            ViewBag.LevelId = new SelectList(db.Levels, "LevelId", "Name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserPassword,ConfirmPassword,UserMatric,UserFirstName,UserLastName,UserType,LevelId,DepartmentId,FacultyId")] User user,FormCollection collectedValues)
        {
            if (ModelState.IsValid)
            {
                var password = collectedValues["ConfirmPassword"];
                user.UserType = typeof(UserType).GetEnumName(int.Parse(collectedValues["UserType"]));
                user.UserPassword = new Md5Ecryption().ConvertStringToMd5Hash(password);
                user.ConfirmPassword = new Md5Ecryption().ConvertStringToMd5Hash(password);
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", user.DepartmentId);
            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "Name", user.FacultyId);
            ViewBag.LevelId = new SelectList(db.Levels, "LevelId", "Name", user.LevelId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", user.DepartmentId);
            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "Name", user.FacultyId);
            ViewBag.LevelId = new SelectList(db.Levels, "LevelId", "Name", user.LevelId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserPassword,ConfirmPassword,UserMatric,UserFirstName,UserLastName,UserType,LevelId,DepartmentId,FacultyId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", user.DepartmentId);
            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "Name", user.FacultyId);
            ViewBag.LevelId = new SelectList(db.Levels, "LevelId", "Name", user.LevelId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
