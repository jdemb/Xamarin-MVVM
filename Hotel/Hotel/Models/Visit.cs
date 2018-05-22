using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace PatientsStory.Models
{
    [Table("Visits")]
    public class Visit
    {
        [PrimaryKey, AutoIncrement]
        public int VisitId { get; set; }

        [ForeignKey(typeof(Patient))]
        public int PatientId { get; set; }

        public DateTime DateOfVisit { get; set; }

        public string Diagnose { get; set; }

        public string Indications { get; set; }

        public Decimal Price { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Patient Patient { get; set; }
    }
}