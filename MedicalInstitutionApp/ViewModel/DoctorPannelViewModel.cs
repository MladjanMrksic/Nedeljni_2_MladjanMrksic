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
    class DoctorPannelViewModel : ViewModelBase
    {
        DoctorPannelView view;
        ClinicDoctorModel docMod = new ClinicDoctorModel();
        public DoctorPannelViewModel(DoctorPannelView dpv)
        {
            view = dpv;
        }

        private List<vwDoctor> doctorList;

        public List<vwDoctor> DoctorList
        {
            get { return doctorList; }
            set { doctorList = value; OnPropertyChanged("DoctorList"); }
        }

        private ClinicDoctor doctor;

        public ClinicDoctor Doctor
        {
            get { return doctor; }
            set { doctor = value; OnPropertyChanged("Doctor"); }
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
            if (Doctor == null)
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
            docMod.DeleteClinicDoctor(Doctor.DoctorID);
        }
        private bool CanDeleteExecute()
        {
            if (Doctor == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand addDoctor;
        public ICommand AddDoctor
        {
            get
            {
                if (addDoctor == null)
                {
                    addDoctor = new RelayCommand(param => AddDoctorExecute(), param => CanAddDoctorExecute());
                }
                return addDoctor;
            }
        }
        private void AddDoctorExecute()
        {
            MessageBox.Show("Functionality not implemented. We are sorry for any inconvenience caused", "Functionality", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private bool CanAddDoctorExecute()
        {
            return true;
        }
    }
}
