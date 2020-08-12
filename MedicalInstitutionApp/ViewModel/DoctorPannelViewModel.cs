using MedicalInstitutionApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInstitutionApp.ViewModel
{
    class DoctorPannelViewModel
    {
        DoctorPannelView view;

        public DoctorPannelViewModel(DoctorPannelView dpv)
        {
            view = dpv;
        }
    }
}
