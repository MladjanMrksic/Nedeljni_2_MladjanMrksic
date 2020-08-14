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
    class RegisterPatientViewModel : ViewModelBase
    {
        RegisterPatientView view;
        ClinicPatientModel patMod = new ClinicPatientModel();
        public RegisterPatientViewModel(RegisterPatientView rpv)
        {
            view = rpv;
        }

        private ClinicPatient patient;

        public ClinicPatient Patient
        {
            get { return patient; }
            set { patient = value; OnPropertyChanged("Patient"); }
        }

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }
        private void SaveExecute()
        {
            patMod.AddClinicPatient(Patient);
        }
        private bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(Patient.Person.FirstName) || String.IsNullOrEmpty(Patient.Person.LastName) || Patient.Person.DateOfBirth > DateTime.Now || String.IsNullOrEmpty(Patient.Person.Residency) || String.IsNullOrEmpty(Patient.Person.Username) || String.IsNullOrEmpty(Patient.Person.Gender) || String.IsNullOrEmpty(Patient.Person.Password) || String.IsNullOrEmpty(Patient.HealthInsuranceCardNumber) || Patient.HealthInsuranceExpiryDate < DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }
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
    }
}
