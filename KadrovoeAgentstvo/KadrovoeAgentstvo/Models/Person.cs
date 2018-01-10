//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KadrovoeAgentstvo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            this.Requests = new HashSet<Request>();
        }
    
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pathronymic { get; set; }
        public string Passport { get; set; }
        public System.DateTime DateBirth { get; set; }
        public Nullable<int> ApplicationId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public int SpecialityId { get; set; }
        public string UserId { get; set; }
        public Nullable<int> ProfileId { get; set; }
    
        public virtual Application Application { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual Speciality Speciality { get; set; }
    }
}
