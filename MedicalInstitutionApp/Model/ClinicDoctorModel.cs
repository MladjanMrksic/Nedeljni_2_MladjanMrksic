﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalInstitutionApp.Model
{
    class ClinicDoctorModel
    {
        public List<vwDoctor> GetAllClinicDoctors()
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    return (from x in context.vwDoctors select x).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public vwDoctor GetClinicDoctor(int ID)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    return (from x in context.vwDoctors where x.DoctorID == ID select x).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void DeleteClinicDoctor(int ID)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    context.ClinicDoctors.Remove((from x in context.ClinicDoctors where x.DoctorID == ID select x).FirstOrDefault());
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AddClinicDoctor(ClinicDoctor d)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    d.Person.Password = Convert.ToString(d.Person.Password.GetHashCode());
                    context.ClinicDoctors.Add(d);
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateClinicDoctor(ClinicDoctor updated)
        {
            try
            {
                using (MedicalInstitutionDatabaseEntities context = new MedicalInstitutionDatabaseEntities())
                {
                    updated.Person.Password = Convert.ToString(updated.Person.Password.GetHashCode());
                    ClinicDoctor d = (from x in context.ClinicDoctors where x.DoctorID == updated.DoctorID select x).FirstOrDefault();
                    d = updated;
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
