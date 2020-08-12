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

        public ClinicOwnerViewModel(ClinicOwnerView cov)
        {
            view = cov;
            if (adminMod.GetClinicAdministrator() == null)
            {
                Administrator = new vwAdministrator();

            }
            else
            {
                Administrator = adminMod.GetClinicAdministrator();
            }            
        }
        
        private vwAdministrator administrator;

        public vwAdministrator Administrator
        {
            get { return administrator; }
            set { administrator = value; OnPropertyChanged("Administrator"); }
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
            if (String.IsNullOrEmpty(administrator.FirstName) || String.IsNullOrEmpty(administrator.LastName) || administrator.DateOfBirth > DateTime.Now || String.IsNullOrEmpty(administrator.Residency) || String.IsNullOrEmpty(administrator.Username) || String.IsNullOrEmpty(administrator.Gender) || String.IsNullOrEmpty(administrator.Password))
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
            if (adminMod.GetAllClinicAdministrators()==null || String.IsNullOrEmpty(administrator.FirstName) || String.IsNullOrEmpty(administrator.LastName) || administrator.DateOfBirth > DateTime.Now || String.IsNullOrEmpty(administrator.Residency) || String.IsNullOrEmpty(administrator.Username) || String.IsNullOrEmpty(administrator.Gender) || String.IsNullOrEmpty(administrator.Password))
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
