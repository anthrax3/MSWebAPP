using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysioAdmin.Models
{
    public class CompleteFortnightly
    {
        MSAppEntities db = new MSAppEntities();

        public List<FortnightlyDiary> fortnight;
        public List<DailyDiary> dailyDiarys;


        public CompleteFortnightly()
        {
            this.fortnight = new List<FortnightlyDiary>();
            this.dailyDiarys = new List<DailyDiary>();
        }

        public List<FortnightlyDiary> Fortnight { get; set; }
        public List<DailyDiary> DailyDiarys { get; set; }

        public CompleteFortnightly(int particpantID,DateTime fortStart)
        {
            DateTime fortEnd = fortStart.AddDays(13);
            this.dailyDiarys = db.DailyDiaries.Where(q => q.Participant_ID == particpantID && q.Fortnightly_Start_Date == fortStart).ToList();
        }
    }
}