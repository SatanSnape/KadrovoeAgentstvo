using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KadrovoeAgentstvo.Models
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Surname {get;set;}
        public string Pathronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string Passport { get; set; }
        public PersonTypeViewModel PersonType { get; set; }

    }
}