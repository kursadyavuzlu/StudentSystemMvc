//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentSystemMvc.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Students
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Students()
        {
            this.Tbl_Notes = new HashSet<Tbl_Notes>();
        }
    
        public int StudentID { get; set; }
        public string StuName { get; set; }
        public string StuSurname { get; set; }
        public string StuImage { get; set; }
        public string StuGender { get; set; }
        public Nullable<byte> StuClub { get; set; }
    
        public virtual Tbl_Clubs Tbl_Clubs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Notes> Tbl_Notes { get; set; }
    }
}