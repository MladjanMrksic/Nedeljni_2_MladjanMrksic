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
    class InstitutionPannelViewModel : ViewModelBase
    {
        InstitutionPannelView view;
        ClinicInstitutionModel instMod = new ClinicInstitutionModel();
        public InstitutionPannelViewModel(InstitutionPannelView ipv)
        {
            view = ipv;
            if (instMod.GetMedicalInstitution() == null)
            {
                Clinic = new MedicalInstitution();
            }
            else
            {
                Clinic = instMod.GetMedicalInstitution();
                view.txtClinicName.Visibility = System.Windows.Visibility.Collapsed;
                view.dpMedicalInstitutionConstructionDate.Visibility = System.Windows.Visibility.Collapsed;
                view.txtClinicAddress.Visibility = System.Windows.Visibility.Collapsed;
                view.txtNumberOfFloors.Visibility = System.Windows.Visibility.Collapsed;
                view.txtNumberOfPatientsPerFloor.Visibility = System.Windows.Visibility.Collapsed;
                view.cmbHasTerrace.Visibility = System.Windows.Visibility.Collapsed;
                view.cmbHasYard.Visibility = System.Windows.Visibility.Collapsed;

                view.lblClinicName.Visibility = System.Windows.Visibility.Collapsed;
                view.lblConstructionDate.Visibility = System.Windows.Visibility.Collapsed;
                view.lblClinicAddress.Visibility = System.Windows.Visibility.Collapsed;
                view.lblNumberOfFloors.Visibility = System.Windows.Visibility.Collapsed;
                view.lblumberOfPatientsPerFloor.Visibility = System.Windows.Visibility.Collapsed;
                view.lblHasTerrace.Visibility = System.Windows.Visibility.Collapsed;
                view.lblHasYard.Visibility = System.Windows.Visibility.Collapsed;

            }
        }

        private MedicalInstitution clinic;

        public MedicalInstitution Clinic
        {
            get { return clinic; }
            set { clinic = value; OnPropertyChanged("Clinic"); }
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
            instMod.AddMedicalInstitution(Clinic);
        }
        private bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(Clinic.ClinicName) || String.IsNullOrEmpty(Clinic.ClinicOwner) || Clinic.MedicalInstitutionConstructionDate > DateTime.Now || String.IsNullOrEmpty(Clinic.ClinicAddress) || Clinic.NumberOfFloors < 1 || Clinic.NumberOfPatientsPerFloor < 1 || Clinic.NumberOfAccessPointsForAmbulance < 1 || Clinic.NumberOfDisabledAccessPoints < 1)
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
            instMod.UpdateMedicalInstitution(Clinic);
        }
        private bool CanUpdateExecute()
        {
            if (instMod.GetAllMedicalInstitution() == null || String.IsNullOrEmpty(Clinic.ClinicOwner) )
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
