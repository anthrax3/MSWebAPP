using PhysioAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhysioAdmin.Controllers
{
    public class ParticipantController : Controller
    {
        MSAppEntities db = new MSAppEntities();
        // GET: Participant
        public ActionResult FornightlyDiarys(int participantID)
        {
            List<FortnightlyDiary> fortDiarys = db.FortnightlyDiaries.Where(q => q.Participant_ID == participantID).ToList();

            CompleteFortnightly complete = new CompleteFortnightly();
            complete.fortnight = fortDiarys;

            return View(complete);
        }

        public PartialViewResult DailyDiary(int participantID, DateTime fortStart)
        {
            CompleteFortnightly complete = new CompleteFortnightly(participantID,fortStart);

            return PartialView(complete);
        }

        public ActionResult Create()
        {
            List<SelectListItem> selectListItem = new List<SelectListItem>();
            foreach(Programme programme in db.Programmes.ToList())
            {
                selectListItem.Add(new SelectListItem { Text = programme.Name, Value = programme.Programme_ID.ToString() });
            }

            ViewBag.programmes = selectListItem;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Participant newPart)
        {
            if (ModelState.IsValid)
            {
                db.Participants.Add(newPart);
                db.SaveChanges();

                return RedirectToAction("Index", "Program", new { id = newPart.Programme_ID });
            }
            else
            {
                return View(newPart);
            }
        }
    }
}