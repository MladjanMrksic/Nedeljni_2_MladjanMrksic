using MedicalInstitutionApp.Command;
using MedicalInstitutionApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MedicalInstitutionApp.ViewModel
{
    class ClinicPatientViewModel
    {
        ClinicPatientView view;
        BackgroundWorker bw = new BackgroundWorker();
        static int counter = 0;
        Random rnd = new Random();
        public ClinicPatientViewModel(ClinicPatientView cpv, ClinicPatient p)
        {
            view = cpv;
            Patient = p;
            bw.WorkerReportsProgress = true;
            bw.ProgressChanged += ProgressChanged;
            bw.DoWork += DoWork;
            bw.RunWorkerCompleted += WorkCompleted;
        }

        private ClinicPatient patient;

        public ClinicPatient Patient
        {
            get { return patient; }
            set { patient = value; }
        }

        private ICommand exam;
        public ICommand Exam
        {
            get
            {
                if (exam == null)
                {
                    exam = new RelayCommand(param => ExamExecute(), param => CanExamExecute());
                }
                return exam;
            }
        }
        private void ExamExecute()
        {
            bw.RunWorkerAsync();
        }
        private bool CanExamExecute()
        {
            if (counter < 2)
            {
                return true;
            }
            else
            {
                return false;
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
            bw.RunWorkerAsync();
        }
        private bool CanLogoutExecute()
        {
            return true;
        }

        void DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for (int i = 1; i < 6; i++)
                {
                    Thread.Sleep(1000);
                    bw.ReportProgress(i * 20);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString());
            }
            Thread.Sleep(2000);
        }

        void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            view.pbExam.Value = e.ProgressPercentage;
        }

        void WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error " + e.Error.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (rnd.Next(1, 3) == 1 && counter < 2)
                {
                    MessageBox.Show("You are suffering from ongoing virus./n Please run tests again to confirm", "Virus infection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    counter++;
                }
                else if (counter == 2)
                {
                    MessageBox.Show("You are confirmed to be suffering from an ongoing virus./n You have been listed as infected. /n Please follow your chosen doctors instructions", "Virus infection confirmed", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    MessageBox.Show("Medical exam option not implemented yet.", "Sorry for inconveniance", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                }
            }
        }
    }
}
