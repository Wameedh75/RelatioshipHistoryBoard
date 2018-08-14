using RelationshipHistoryBoard.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace RelationshipHistoryBoard.Controllers
{
    public class SurveyOccationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SurveyOccations
        public ActionResult Index()
        {
            var surveyOccations = db.SurveyOccations.Include(s => s.Survey);
            return View(surveyOccations.ToList());
        }

        // GET: SurveyOccations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyOccation surveyOccation = db.SurveyOccations.Find(id);
            var questions = db.Questions.Where(sq => sq.SurveyOccation.Id == id);
            if (surveyOccation!= null)
            {
                surveyOccation.Questionses = questions;
            }

            if (surveyOccation == null)
            {
                return HttpNotFound();
            }
            return View(surveyOccation);
        }

        // GET: SurveyOccations/Create
        public ActionResult Create()
        {
            ViewBag.SurveyId = new SelectList(db.Surveys, "Id", "Name");
            return View();
        }

        // POST: SurveyOccations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartDate,EndDate,SurveyId")] SurveyOccation surveyOccation)
        {
            if (ModelState.IsValid)
            {
                db.SurveyOccations.Add(surveyOccation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SurveyId = new SelectList(db.Surveys, "Id", "Name", surveyOccation.SurveyId);
            return View(surveyOccation);
        }

        // GET: SurveyOccations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyOccation surveyOccation = db.SurveyOccations.Find(id);
            if (surveyOccation == null)
            {
                return HttpNotFound();
            }
            ViewBag.SurveyId = new SelectList(db.Surveys, "Id", "Name", surveyOccation.SurveyId);
            return View(surveyOccation);
        }

        // POST: SurveyOccations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDate,EndDate,SurveyId")] SurveyOccation surveyOccation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(surveyOccation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SurveyId = new SelectList(db.Surveys, "Id", "Name", surveyOccation.SurveyId);
            return View(surveyOccation);
        }

        // GET: SurveyOccations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyOccation surveyOccation = db.SurveyOccations.Find(id);
            if (surveyOccation == null)
            {
                return HttpNotFound();
            }
            return View(surveyOccation);
        }

        // POST: SurveyOccations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SurveyOccation surveyOccation = db.SurveyOccations.Find(id);
            db.SurveyOccations.Remove(surveyOccation);
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
