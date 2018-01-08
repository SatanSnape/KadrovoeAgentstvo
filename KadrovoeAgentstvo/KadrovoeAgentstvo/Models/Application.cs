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
    
    public partial class Application
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Application()
        {
            this.People = new HashSet<Person>();
        }
    
        public int ApplicationId { get; set; }
        public System.DateTime Date { get; set; }
        public int JobDirectoryId { get; set; }
        public int SpecialityId { get; set; }
        public string State { get; set; }
        public string Duties { get; set; }
        public string Requirements { get; set; }
    
        public virtual JobDirectory JobDirectory { get; set; }
        public virtual Speciality Speciality { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> People { get; set; }
    }
}
