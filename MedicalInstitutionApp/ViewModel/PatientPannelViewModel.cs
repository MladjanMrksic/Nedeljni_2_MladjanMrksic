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
    class PatientPannelViewModel : ViewModelBase
    {
        PatientPannelView view;
        ClinicPatientModel patMod = new ClinicPatientModel();
        public PatientPannelViewModel(PatientPannelView ppv)
        {
            view = ppv;
        }

        private List<vwPatient> patientList;

        public List<vwPatient> PatientList
        {
            get { return patientList; }
            set { patientList = value; OnPropertyChanged("PatientList"); }
        }

        private ClinicPatient patient;

        public ClinicPatient Patient
        {
            get { return patient; }
            set { patient = value; OnPropertyChanged("Patient"); }
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
            if (Patient == null)
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
            patMod.DeleteClinicPatient(Patient.PatientID);
        }
        private bool CanDeleteExecute()
        {
            if (Patient == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand addPatient;
        public ICommand AddPatient
        {
            get
            {
                if (addPatient == null)
                {
                    addPatient = new RelayCommand(param => AddPatientExecute(), param => CanAddPatientExecute());
                }
                return addPatient;
            }
        }
        private void AddPatientExecute()
        {
            MessageBox.Show("Functionality not implemented. We are sorry for any inconvenience caused", "Functionality", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private bool CanAddPatientExecute()
        {
            return true;
        }
    }
}
