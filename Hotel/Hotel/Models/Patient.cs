using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace PatientsStory.Models
{
    [Table("Patients")]
    public class Patient
    {
        [PrimaryKey, AutoIncrement]
        public int PatientId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string PESEL { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Visit> Visits { get; set; }
    }
}