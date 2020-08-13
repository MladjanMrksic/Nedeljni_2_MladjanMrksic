using MedicalInstitutionApp.Command;
using MedicalInstitutionApp.Model;
using MedicalInstitutionApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MedicalInstitutionApp.ViewModel
{
    class MaintenancePannelViewModel : ViewModelBase
    {
        MaintenancePannelView view;
        ClinicMaintenanaceModel mainMod = new ClinicMaintenanaceModel();
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

        private ICommand update;
        public ICommand Update
        {
            get
            {
                if (update == null)
                {
                    update = new RelayCommand(param => UpdateExecute(), param => CanUpdateExecute());
                }
                return update;
            }
        }
        private void UpdateExecute()
        {
            MessageBox.Show("Functionality not implemented. We are sorry for any inconvenience caused", "Functionality", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private bool CanUpdateExecute()
        {
            if (Maintenance == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand delete;
        public ICommand Delete
        {
            get
            {
                if (delete == null)
                {
                    delete = new RelayCommand(param => DeleteExecute(), param => CanDeleteExecute());
                }
                return delete;
            }
        }
        private void DeleteExecute()
        {
            mainMod.DeleteClinicMaintenance(Maintenance.MaintenanaceID);
        }
        private bool CanDeleteExecute()
        {
            if (Maintenance == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand addMaintenance;
        public ICommand AddMaintenance
        {
            get
            {
                if (addMaintenance == null)
                {
                    addMaintenance = new RelayCommand(param => AddMaintenanceExecute(), param => CanAddMaintenanceExecute());
                }
                return addMaintenance;
            }
        }
        private void AddMaintenanceExecute()
        {
            MessageBox.Show("Functionality not implemented. We are sorry for any inconvenience caused", "Functionality", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private bool CanAddMaintenanceExecute()
        {
                return true;
        }
    }
}
