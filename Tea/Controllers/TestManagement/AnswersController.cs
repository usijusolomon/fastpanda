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
    public class AnswersController : Controller
    {
        private readonly AnswerDataBaseConnection db = new AnswerDataBaseConnection();

        // GET: Answers
        public ActionResult Index()
        {
            var answers = db.Answers.Include(a => a.Question);
            return View(answers.ToList());
        }

        public ActionResult ProcessAnswers([Bind(Include = "AnswerId,QuestionId,QuestionAnswer,RightAnswer,Label")] Answer answer,FormCollection collectedValues)
        {

     
           
            //collect test id
            var questionNumber = Convert.ToInt64(collectedValues["id"]);
            var rightAnswer = collectedValues["RightAnswer"];

            //collect questions
            var questionAnswer = collectedValues["QuestionAnswer"];

            //create a session to store question
            var question = Session["question"] as Question;
            char c1 = 'A';
            if (question != null)
            {
                int numberOfAnswers = 0;
                if (question.Answers != null && question.Answers.Count > 0)
                {
                    numberOfAnswers = question.Answers.ToList().Count;
                }
                char label = (char)(c1 + numberOfAnswers);

                if (question != null)
                {
                    if (question.Answers == null)
                        question.Answers = new List<Answer>();

                    question.Answers.Add(new Answer
                    {
                        QuestionAnswer = questionAnswer,
                        QuestionNumber = questionNumber,
                        RightAnswer = answer.RightAnswer,
                        Label = label
                    });
                }
            }
            //store back in session
            Session["question"] = question;

            //redirect to same view and pass test id
            return RedirectToAction("Create", new {id = questionNumber});
        }


        // GET: Answers/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var answer = db.Answers.Find(id);
            if (answer == null)
                return HttpNotFound();
            return View(answer);
        }

        // GET: Answers/Create
        public ActionResult Create(long? id)
        {
            var question = Session["question"] as Question;
            var test = Session["test"] as Test;

            //check session and see if its empty
            if (question == null)
            {
                if (test != null) question = test.Questions.SingleOrDefault(n=>n.QuestionNumber == id);
                Session["question"] = question;
            }
            ViewBag.id = id;
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "AnswerId,QuestionId,QuestionAnswer,RightAnswer,Label")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Answers.Add(answer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "AskedQuestion", answer.QuestionId);
            return View(answer);
        }

        // GET: Answers/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var answer = db.Answers.Find(id);
            if (answer == null)
                return HttpNotFound();
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "AskedQuestion", answer.QuestionId);
            return View(answer);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnswerId,QuestionId,QuestionAnswer,RightAnswer,Label")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "AskedQuestion", answer.QuestionId);
            return View(answer);
        }

        // GET: Answers/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var answer = db.Answers.Find(id);
            if (answer == null)
                return HttpNotFound();
            return View(answer);
        }

        // POST: Answers/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var answer = db.Answers.Find(id);
            db.Answers.Remove(answer);
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