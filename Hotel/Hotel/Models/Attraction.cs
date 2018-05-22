using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Models
{
    [Table("Attraction")]
    public class Attraction
    {
        [PrimaryKey, AutoIncrement]
        public int AttractionId { get; set; }
        
        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Description { get; set; }
    }
}
