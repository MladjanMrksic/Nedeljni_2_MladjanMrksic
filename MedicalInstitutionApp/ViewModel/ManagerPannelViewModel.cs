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
    class ManagerPannelViewModel : ViewModelBase
    {
        ManagerPannelView view;
        ClinicManagerModel manMod = new ClinicManagerModel();
        public ManagerPannelViewModel(ManagerPannelView mpv)
        {
            view = mpv;
        }

        private List<vwManager> managerList;

        public List<vwManager> ManagerList
        {
            get { return managerList; }
            set { managerList = value; OnPropertyChanged("ManagerList"); }
        }

        private ClinicManager manager;

        public ClinicManager Manager
        {
            get { return manager; }
            set { manager = value; OnPropertyChanged("Manager"); }
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
            if (Manager == null)
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
            manMod.DeleteClinicManager(Manager.ManagerID);
        }
        private bool CanDeleteExecute()
        {
            if (Manager == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand addManager;
        public ICommand AddManager
        {
            get
            {
                if (addManager == null)
                {
                    addManager = new RelayCommand(param => AddManagerExecute(), param => CanAddManagerExecute());
                }
                return addManager;
            }
        }
        private void AddManagerExecute()
        {
            MessageBox.Show("Functionality not implemented. We are sorry for any inconvenience caused", "Functionality", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private bool CanAddManagerExecute()
        {
            return true;
        }
    }
}
