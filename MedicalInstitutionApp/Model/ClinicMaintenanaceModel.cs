using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalInstitutionApp.Model
{
    class ClinicMaintenanaceModel
    {
        public List<vwMaintenance> GetAllClinicMaintenance()
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    return (from x in context.vwMaintenances select x).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public vwMaintenance GetClinicMaintenance(int ID)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    return (from x in context.vwMaintenances where x.MaintenanaceID == ID select x).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void DeleteClinicMaintenance(int ID)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    context.ClinicMaintenances.Remove((from x in context.ClinicMaintenances where x.MaintenanaceID == ID select x).FirstOrDefault());
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AddClinicMaintenanace(ClinicMaintenance m)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    m.Person.Password = Convert.ToString(m.Person.Password.GetHashCode());
                    context.ClinicMaintenances.Add(m);
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateClinicMaintenance(ClinicMaintenance updated)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    updated.Person.Password = Convert.ToString(updated.Person.Password.GetHashCode());
                    ClinicMaintenance m = (from x in context.ClinicMaintenances where x.MaintenanaceID == updated.MaintenanaceID select x).FirstOrDefault();
                    m = updated;
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
