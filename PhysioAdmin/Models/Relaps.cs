//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhysioAdmin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Relaps
    {
        public int Participant_ID { get; set; }
        public System.DateTime Start_Date { get; set; }
        public int Record_ID { get; set; }
        public Nullable<System.DateTime> Relapse_Start { get; set; }
        public Nullable<int> Duration { get; set; }
        public string Symptoms { get; set; }
        public Nullable<bool> ConsultHP { get; set; }
        public string HPVisted { get; set; }
        public string Treatments { get; set; }
    }
}
