using MedicalInstitutionApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInstitutionApp.ViewModel
{
    class MaintenancePannelViewModel : ViewModelBase
    {
        MaintenancePannelView view;

        public MaintenancePannelViewModel(MaintenancePannelView mpv)
        {
            view = mpv;
        }

        private List<vwMaintenance> maintenanceList;
        public List<vwMaintenance> MaintenanceList
        {
            get { return maintenanceList; }
            set { maintenanceList = value; OnPropertyChanged("MaintenanceList"); }
        }

        private ClinicMaintenance maintenance;

        public ClinicMaintenance Maintenance
        {
            get { return maintenance; }
            set { maintenance = value; OnPropertyChanged("Maintenance"); }
        }


    }
}
