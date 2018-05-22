using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Models
{
    [Table("Reservation")]
    public class Reservation
    {
        [PrimaryKey, AutoIncrement]
        public int ReservationId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Type { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int AmountOfBeds { get; set; }
    }
}
