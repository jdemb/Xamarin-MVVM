using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Helpers
{
    class AttractionHelper
    {
        public List<Attraction> createAttractions()
        {
            List<Attraction> list = new List<Attraction>();
            Attraction att1 = new Attraction();
            att1.AttractionId = 1;
            att1.Name = "Nauka Salsy";
            att1.Description = "Nauka z najlepszym instruktorem tańca w mieście \n";
            att1.StartTime = new DateTime(); att1.StartTime = att1.StartTime.Date + new TimeSpan(10, 30, 0);
            att1.EndTime = new DateTime(); att1.EndTime = att1.EndTime.Date + new TimeSpan(12, 00, 0);
            Attraction att2 = new Attraction();
            att2.AttractionId = 2;
            att2.Name = "Surfing";
            att2.Description = "Daj się ponieść falom w naszej pięknej zatoce \n";
            att2.StartTime = new DateTime(); att2.StartTime = att2.StartTime.Date + new TimeSpan(14, 00, 0);
            att2.EndTime = new DateTime(); att2.EndTime = att2.EndTime.Date + new TimeSpan(16, 00, 0);
            Attraction att3 = new Attraction();
            att3.AttractionId = 3;
            att3.Name = "Bankiet";
            att3.Description = "Poznaj współtowarzyszy turnusu \n";
            att3.StartTime = new DateTime(); att3.StartTime = att3.StartTime.Date + new TimeSpan(19, 00, 0);
            att3.EndTime = new DateTime(); att3.EndTime = att3.EndTime.Date + new TimeSpan(23, 00, 0);
            list.Add(att1);
            list.Add(att2);
            list.Add(att3);
            return list;
        }
    }
}
