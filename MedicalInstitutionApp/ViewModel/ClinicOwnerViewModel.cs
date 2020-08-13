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
    class ClinicOwnerViewModel:ViewModelBase
    {
        ClinicOwnerView view;
        ClinicAdministratorModel adminMod = new ClinicAdministratorModel();
        ClinicPersonModel perMod = new ClinicPersonModel();
        public ClinicOwnerViewModel(ClinicOwnerView cov)
        {
            view = cov;
            if (adminMod.GetClinicAdministrator() == null)
            {
                Administrator = new ClinicAdministrator();
                Person = new Person();

            }
            else
            {
                Administrator = adminMod.GetClinicAdministrator();
                Person = perMod.GetClinicPerson(Administrator.PersonID);
            }            
        }
        
        private ClinicAdministrator administrator;

        public ClinicAdministrator Administrator
        {
            get { return administrator; }
            set { administrator = value; OnPropertyChanged("Administrator"); }
        }

        private Person person;

        public Person Person
        {
            get { return person; }
            set { person = value; }
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
            adminMod.AddClinicAdministrator(Administrator);
        }
        private bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(Person.FirstName) || String.IsNullOrEmpty(Person.LastName) || Person.DateOfBirth > DateTime.Now || String.IsNullOrEmpty(Person.Residency) || String.IsNullOrEmpty(Person.Username) || String.IsNullOrEmpty(Person.Gender) || String.IsNullOrEmpty(Person.Password))
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
            adminMod.UpdateClinicAdministrator(Administrator);
        }
        private bool CanUpdateExecute()
        {
            if (adminMod.GetAllClinicAdministrators()==null || String.IsNullOrEmpty(Person.FirstName) || String.IsNullOrEmpty(Person.LastName) || Person.DateOfBirth > DateTime.Now || String.IsNullOrEmpty(Person.Residency) || String.IsNullOrEmpty(Person.Username) || String.IsNullOrEmpty(Person.Gender) || String.IsNullOrEmpty(Person.Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
