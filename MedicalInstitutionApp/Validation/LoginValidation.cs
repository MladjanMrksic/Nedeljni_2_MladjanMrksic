using MedicalInstitutionApp.Model;
using MedicalInstitutionApp.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalInstitutionApp.Validation
{
    class LoginValidation
    {
        StreamReader sr;
        public void Login(string username, string password, LoginView login)
        {
            ClinicMaintenanaceModel maintenance = new ClinicMaintenanaceModel();
            ClinicManagerModel manager = new ClinicManagerModel();
            ClinicDoctorModel doctor = new ClinicDoctorModel();
            ClinicPatientModel patient = new ClinicPatientModel();
            ClinicAdministratorModel administrator = new ClinicAdministratorModel();

            List<vwMaintenance> MaintenanceList = maintenance.GetAllClinicMaintenance();
            List<vwManager> ManagerList = manager.GetAllClinicManagers();
            List<vwDoctor> DoctorList = doctor.GetAllClinicDoctors();
            List<vwPatient> PatientList = patient.GetAllClinicPatients();
            List<vwAdministrator> AdministratorList = administrator.GetAllClinicAdministrators();
            List<string> OwnerAccess = GetClinicAccessCredentials();

            if (username == OwnerAccess[0] && password == OwnerAccess[1])
            {
                ClinicOwnerView cov = new ClinicOwnerView();
                cov.Show();
                login.Close();
            }
            else if (AdministratorList.Contains((from x in AdministratorList where x.Username == username && x.Password == password select x).FirstOrDefault()))
            {
                ClinicAdministratorView cav = new ClinicAdministratorView();
                cav.Show();
                login.Close();
            }
            else if (MaintenanceList.Contains((from x in MaintenanceList where x.Username == username && x.Password == password select x).FirstOrDefault()))
            {
                ClinicMaintenanaceView cmv = new ClinicMaintenanaceView((from x in MaintenanceList where x.Username == username && x.Password == password select x).FirstOrDefault());
                cmv.Show();
                login.Close();
            }
            else if (ManagerList.Contains((from x in ManagerList where x.Username == username && x.Password == password select x).FirstOrDefault()))
            {
                ClinicManagerView cmv = new ClinicManagerView((from x in ManagerList where x.Username == username && x.Password == password select x).FirstOrDefault());
                cmv.Show();
                login.Close();
            }
            else if (DoctorList.Contains((from x in DoctorList where x.Username == username && x.Password == password select x).FirstOrDefault()))
            {
                ClinicDoctorView cdv = new ClinicDoctorView((from x in DoctorList where x.Username == username && x.Password == password select x).FirstOrDefault());
                cdv.Show();
                login.Close();
            }
            else if (PatientList.Contains((from x in PatientList where x.Username == username && x.Password == password select x).FirstOrDefault()))
            {
                ClinicPatientView cpv = new ClinicPatientView((from x in PatientList where x.Username == username && x.Password == password select x).FirstOrDefault());
                cpv.Show();
                login.Close();
            }
            else
            {
                MessageBox.Show("Credentials are incorrect!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public List<string> GetClinicAccessCredentials()
        {
            List<string> AccessInfo = new List<string>();
            sr = new StreamReader(@"...\...\ClinicAccess.txt");
            using (sr)
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    AccessInfo.Add(line);
                }
            }
            return AccessInfo;
        }
    }
}
