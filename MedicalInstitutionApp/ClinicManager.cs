//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedicalInstitutionApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClinicManager
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClinicManager()
        {
            this.ClinicDoctors = new HashSet<ClinicDoctor>();
        }
    
        public int ManagerID { get; set; }
        public int PersonID { get; set; }
        public Nullable<int> ClinicFloor { get; set; }
        public Nullable<int> MaximumNumberOfDoctorsUnderSupervision { get; set; }
        public Nullable<int> MinimumNumberOfPersonelUnderSupervision { get; set; }
        public Nullable<int> NumberOfOversights { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClinicDoctor> ClinicDoctors { get; set; }
        public virtual Person Person { get; set; }
    }
}