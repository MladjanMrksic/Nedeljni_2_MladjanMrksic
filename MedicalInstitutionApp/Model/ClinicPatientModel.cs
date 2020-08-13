using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalInstitutionApp.Model
{
    class ClinicPatientModel
    {
        public List<vwPatient> GetAllClinicPatients()
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    return (from x in context.vwPatients select x).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public vwPatient GetClinicPatient(int ID)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    return (from x in context.vwPatients where x.PatientID == ID select x).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void DeleteClinicPatient(int ID)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    context.ClinicPatients.Remove((from x in context.ClinicPatients where x.PatientID == ID select x).FirstOrDefault());
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AddClinicPatient(ClinicPatient p)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    p.Person.Password = Convert.ToString(p.Person.Password.GetHashCode());
                    context.ClinicPatients.Add(p);
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateClinicPatient(ClinicPatient updated)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    updated.Person.Password = Convert.ToString(updated.Person.Password.GetHashCode());
                    ClinicPatient p = (from x in context.ClinicPatients where x.PatientID == updated.PatientID select x).FirstOrDefault();
                    p = updated;
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
