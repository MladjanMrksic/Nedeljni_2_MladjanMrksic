using MedicalInstitutionApp.Command;
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
    class ClinicAdministratorViewModel : ViewModelBase
    {
        ClinicAdministratorView view;

        public ClinicAdministratorViewModel(ClinicAdministratorView cav)
        {
            view = cav;
        }

        private ICommand maintenancePannel;
        public ICommand MaintenancePannel
        {
            get
            {
                if (maintenancePannel == null)
                {
                    maintenancePannel = new RelayCommand(param => MaintenancePannelExecute(), param => CanMaintenancePannelExecute());
                }
                return maintenancePannel;
            }
        }
        private void MaintenancePannelExecute()
        {
            MaintenancePannelView mpv = new MaintenancePannelView();
            mpv.ShowDialog();
        }
        private bool CanMaintenancePannelExecute()
        {
            return true;
        }

        private ICommand managerPannel;
        public ICommand ManagerPannel
        {
            get
            {
                if (managerPannel == null)
                {
                    managerPannel = new RelayCommand(param => ManagerPannelExecute(), param => CanManagerPannelExecute());
                }
                return managerPannel;
            }
        }
        private void ManagerPannelExecute()
        {
            ManagerPannelView mpv = new ManagerPannelView();
            mpv.ShowDialog();
        }
        private bool CanManagerPannelExecute()
        {
            return true;
        }

        private ICommand doctorPannel;
        public ICommand DoctorPannel
        {
            get
            {
                if (doctorPannel == null)
                {
                    doctorPannel = new RelayCommand(param => DoctorPannelExecute(), param => CanDoctorPannelExecute());
                }
                return doctorPannel;
            }
        }
        private void DoctorPannelExecute()
        {
            DoctorPannelView dpv = new DoctorPannelView();
            dpv.ShowDialog();
        }
        private bool CanDoctorPannelExecute()
        {
            return true;
        }

        private ICommand patientPannel;
        public ICommand PatientPannel
        {
            get
            {
                if (patientPannel == null)
                {
                    patientPannel = new RelayCommand(param => PatientPannelExecute(), param => CanPatientPannelExecute());
                }
                return patientPannel;
            }
        }
        private void PatientPannelExecute()
        {
            PatientPannelView ppv = new PatientPannelView();
            ppv.ShowDialog();
        }
        private bool CanPatientPannelExecute()
        {
            return true;
        }

        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logout;
            }
        }
        private void LogoutExecute()
        {
            try
            {
                LoginView lv = new LoginView();
                lv.Show();
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.Message.ToString());
            }
        }
        private bool CanLogoutExecute()
        {
            return true;
        }

        private ICommand institutionPannel;
        public ICommand InstitutionPannel
        {
            get
            {
                if (institutionPannel == null)
                {
                    institutionPannel = new RelayCommand(param => InstitutionPannelExecute(), param => CanInstitutionPannelExecute());
                }
                return institutionPannel;
            }
        }
        private void InstitutionPannelExecute()
        {
            try
            {
                InstitutionPannelView ipv = new InstitutionPannelView();
                ipv.Show();
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.Message.ToString());
            }
        }
        private bool CanInstitutionPannelExecute()
        {
            return true;
        }
    }
}
