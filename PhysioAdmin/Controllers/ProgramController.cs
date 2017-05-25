using PhysioAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhysioAdmin.Controllers
{
    public class ProgramController : Controller
    {
        MSAppEntities db = new MSAppEntities();
        // GET: Program
        public ActionResult Index()
        {
            List<Programme> program = db.Programmes.ToList();

            return View(program);
        }

        public ActionResult Participants(int id)
        {
            TempData["programme"] = db.Programmes.Find(id);
            List<Participant> participants = db.Participants.Where(d => d.Programme_ID == id).ToList();
        
            return View(participants);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Programme programme)
        {
            if (ModelState.IsValid)
            {
                db.Programmes.Add(programme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(programme);
            }
        }

        public ActionResult ExportToCSV(int id, string groupBy)
        {
            ProgrammeExport programme = new ProgrammeExport(id);
            string csv = "";
            
            //First row programme info
            csv += programme.Programme.Name +
                "," + programme.Programme.Programme_ID +
                ", Capacity: " + programme.Programme.Capacity +
                ", Duration: " + programme.Programme.Duration +
                ", Paticipants: " + programme.ParticipantCount +
                "\r\n";

            if(groupBy == "fortnight")
            {
                foreach(FortnightlyDiary record in programme.FortnightDiarys.OrderBy(d => d.Participant_ID).GroupBy(d => d.DiaryStart))
                {
                    csv += record.DiaryStart +
                        "," + record.Participant_ID +
                        "," + record.FallCount +
                        "," + record.SeriousFallCount +
                        "," + record.NurseVisitCount +
                        "," + record.GPVisitCount +
                        "," + record.SpecDocVisitCount +
                        "," + record.EmergencyDeptCount +
                        "," + record.DaysHospitalized +
                        "," + record.Grounded_10___30 +
                        "," + record.Grounded_30___60 +
                        "," + record.Grounded__60 +
                        "," + record.HelpFamily +
                        "," + record.HelpFriendNeighbour +
                        "," + record.SpecDocSeen +
                        "," + record.OtherCount +
                        "," + record.OtherSeen +
                        "," + record.HelpOther +
                        "\r\n";
            }

            }
            else if(groupBy == "participant")
            {
                foreach (FortnightlyDiary record in programme.FortnightDiarys.OrderBy(d => d.DiaryStart).GroupBy(d => d.Participant_ID)) {
                    csv += record.Participant_ID +
                        "," + record.DiaryStart +
                        "," + record.FallCount +
                        "," + record.SeriousFallCount +
                        "," + record.NurseVisitCount +
                        "," + record.GPVisitCount +
                        "," + record.SpecDocVisitCount +
                        "," + record.EmergencyDeptCount +
                        "," + record.DaysHospitalized + 
                        "," + record.Grounded_10___30 +
                        "," + record.Grounded_30___60 +
                        "," + record.Grounded__60 +
                        "," + record.HelpFamily +
                        "," + record.HelpFriendNeighbour +
                        "," + record.SpecDocSeen +
                        "," + record.OtherCount + 
                        "," + record.OtherSeen +
                        "," + record.HelpOther +                        
                        "\r\n";

                }   
            }
 
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ProgrammeExport.csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
            Response.Output.Write(csv);
            Response.Flush();
            Response.End();

            return RedirectToAction("Index");
        }
    }
}