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
    
    public partial class ClinicPatient
    {
        public int PatientID { get; set; }
        public int PersonID { get; set; }
        public string HealthInsuranceCardNumber { get; set; }
        public Nullable<System.DateTime> HealthInsuranceExpiryDate { get; set; }
        public Nullable<int> ChosenDoctor { get; set; }
    
        public virtual ClinicDoctor ClinicDoctor { get; set; }
        public virtual Person Person { get; set; }
    }
}
