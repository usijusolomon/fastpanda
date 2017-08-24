using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DataBase.DataContext;
using ObjectClass.Objects;

namespace Tea.Controllers.TestManagement
{
    public class QuestionsController : Controller
    {
        private readonly FacultyDataBaseConnection db = new FacultyDataBaseConnection();

        // GET: Questions
        public ActionResult Index()
        {
            var questions = db.Questions.Include(q => q.Test);
            return View(questions.ToList());
        }

        // GET: Questions/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var question = db.Questions.Find(id);
            if (question == null)
                return HttpNotFound();
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create(long? id)
        {
            var test = Session["test"] as Test;
            //check session 
            if (test == null)
            {
                test = db.Tests.Find(id);
                Session["test"] = test;
            }
            ViewBag.id = id;
            return View();
        }

        public ActionResult ProcessQuestions(FormCollection collectedValues)
        {
            //collect test id
            var testId = Convert.ToInt64(collectedValues["id"]);

            //collect question
            var question = collectedValues["AskedQuestion"];

            //create a session to store question
            var test = Session["test"] as Test;

            if (test != null)
            {
                if (test.Questions == null)
                    test.Questions = new List<Question>();

                test.Questions.Add(new Question
                {
                    AskedQuestion = question,
                    TestId = testId,
                    QuestionNumber = test.Questions.Count + 1
                });
            }
            //store back in session
            Session["test"] = test;

            //redirect to same view and pass test id
            return RedirectToAction("Create", new {id = testId});
        }


        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "QuestionId,TestId,AskedQuestion,QuestionNumber,Image")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(question);
        }

        public ActionResult SaveQuestionsAndAnswers()
        {
            var question = Session["question"] as Question;
            var test = Session["test"] as Test;
            var overallScore = test.OverallScore;
            var questionScore = overallScore/test.Questions.Count;

            if (test != null)
                foreach (var item in test.Questions)
                {
                    long? questionId = item.QuestionId;
                    db.Questions.Add(item);
                    if (question != null)
                    {
                        var questionAnswers = question.Answers.Where(n => n.QuestionNumber == item.QuestionNumber);
                        foreach (var items in questionAnswers)
                        {
                            items.QuestionId = (long) questionId;
                            db.Answers.Add(items);
                        }
                    }
                }
            db.SaveChanges();
            return RedirectToAction("Create",new {id = test.TestId});
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var question = db.Questions.Find(id);
            if (question == null)
                return HttpNotFound();
            ViewBag.TestId = new SelectList(db.Tests, "TestId", "Name", question.TestId);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "QuestionId,TestId,AskedQuestion,QuestionNumber,Image")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TestId = new SelectList(db.Tests, "TestId", "Name", question.TestId);
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var question = db.Questions.Find(id);
            if (question == null)
                return HttpNotFound();
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var question = db.Questions.Find(id);
            db.Questions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}