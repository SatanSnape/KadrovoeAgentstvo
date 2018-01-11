using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KadrovoeAgentstvo.Models
{
    public class Profs
    {
        public int ProfileId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string State { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Speciality { get; set; }
    }
}