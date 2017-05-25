using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysioAdmin.Models
{
    public class ProgrammeExport
    {
        MSAppEntities db = new MSAppEntities();
        Programme programme;
        List<FortnightlyDiary> fortnightDiarys;
        int participantCount;

        public ProgrammeExport()
        {
            this.programme = new Programme();
            this.fortnightDiarys = new List<FortnightlyDiary>();
            this.participantCount = 0;
        }

        public ProgrammeExport(int id)
        {
            List<Participant> programmeParticipants = new List<Participant>();
            programmeParticipants = db.Participants.Where(p => p.Programme_ID == id).ToList();

            this.programme = db.Programmes.Find(id);
            this.participantCount = programmeParticipants.Count();

            foreach (Participant part in programmeParticipants)
            {
                this.fortnightDiarys.AddRange(db.FortnightlyDiaries.Where(d => d.Participant_ID == part.Participant_ID).ToList());
            }

        }

        public int ParticipantCount { get; set; }
        public Programme Programme { get; set; }
        public List<FortnightlyDiary> FortnightDiarys { get; set; }
    }
}