using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalInstitutionApp.Model
{
    class ClinicInstitutionModel
    {

        public List<MedicalInstitution> GetAllMedicalInstitution()
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    return (from x in context.MedicalInstitutions select x).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public MedicalInstitution GetMedicalInstitution()
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    return (from x in context.MedicalInstitutions select x).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void DeleteMedicalInstitution(int ID)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    context.MedicalInstitutions.Remove((from x in context.MedicalInstitutions where x.MedicalInstitutionID == ID select x).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AddMedicalInstitution(MedicalInstitution mi)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    context.MedicalInstitutions.Add(mi);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateMedicalInstitution(MedicalInstitution updated)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    MedicalInstitution mi = (from x in context.MedicalInstitutions where x.MedicalInstitutionID == updated.MedicalInstitutionID select x).FirstOrDefault();
                    mi = updated;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
