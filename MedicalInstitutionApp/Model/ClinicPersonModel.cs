using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalInstitutionApp.Model
{
    class ClinicPersonModel
    {
        public List<Person> GetAllClinicPeople()
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    return (from x in context.People select x).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public Person GetClinicPerson(int ID)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    return (from x in context.People where x.PersonID == ID select x).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void DeleteClinicPerson (int ID)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    context.People.Remove((from x in context.People where x.PersonID == ID select x).FirstOrDefault());
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AddClinicPerson(Person p)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    context.People.Add(p);
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateClinicPerson(Person updated)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    Person p = (from x in context.People where x.PersonID == updated.PersonID select x).FirstOrDefault();
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
