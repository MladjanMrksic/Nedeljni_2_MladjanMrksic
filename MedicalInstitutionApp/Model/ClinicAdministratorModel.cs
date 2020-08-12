using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalInstitutionApp.Model
{
    class ClinicAdministratorModel
    {
        public List<vwAdministrator> GetAllClinicAdministrators()
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    return (from x in context.vwAdministrators select x).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public vwAdministrator GetClinicAdministrator()
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    return (from x in context.vwAdministrators select x).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void DeleteClinicAdministrator(int ID)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    context.vwAdministrators.Remove((from x in context.vwAdministrators where x.AdministratorID == ID select x).FirstOrDefault());
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AddClinicAdministrator(vwAdministrator admin)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    admin.Password = Convert.ToString(admin.Password.GetHashCode());
                    context.vwAdministrators.Add(admin);
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateClinicAdministrator(vwAdministrator updated)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    updated.Password = Convert.ToString(updated.Password.GetHashCode());
                    vwAdministrator admin = (from x in context.vwAdministrators where x.AdministratorID == updated.AdministratorID select x).FirstOrDefault();
                    admin = updated;
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
