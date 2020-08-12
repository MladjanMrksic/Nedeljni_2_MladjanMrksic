using MedicalInstitutionApp.Model;
using MedicalInstitutionApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInstitutionApp.ViewModel
{
    class CreateAdministratorViewModel : ViewModelBase
    {
        CreateAdministratorView view;
        ClinicAdministratorModel adminMod = new ClinicAdministratorModel();

        public CreateAdministratorViewModel(CreateAdministratorView cav)
        {
            view = cav;
            Administrator = adminMod.GetClinicAdministrator();
            if (Administrator == null)
            {
                view.btnSave.Visibility = System.Windows.Visibility.Visible;
                view.btnUpdate.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (Administrator != null)
            {
                view.btnSave.Visibility = System.Windows.Visibility.Hidden;
                view.btnUpdate.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private vwAdministrator administrator;

        public vwAdministrator Administrator
        {
            get { return Administrator; }
            set { Administrator = value; OnPropertyChanged("Administrator"); }
        }


    }
}
