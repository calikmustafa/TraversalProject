using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Rezervation
    {
        public int RezervationID { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string PersonCount { get; set; }
        public DateTime RezervationDate { get; set; }
        public string Description { get; set; }
        public string? Status { get; set; }
        public int DestinationID { get; set; }
        public Destination Destination { get; set; }
    }
}
