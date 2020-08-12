using MedicalInstitutionApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInstitutionApp.ViewModel
{
    class PatientPannelViewModel
    {
        PatientPannelView view;

        public PatientPannelViewModel(PatientPannelView ppv)
        {
            view = ppv;
        }
    }
}
