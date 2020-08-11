using MedicalInstitutionApp.Command;
using MedicalInstitutionApp.Validation;
using MedicalInstitutionApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalInstitutionApp.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        LoginView view;
        LoginValidation lv = new LoginValidation();
        public LoginViewModel(LoginView lv)
        {
            view = lv;
        }

        private ICommand submit;

        public ICommand Submit
        {
            get
            {
                if (submit == null)
                {
                    submit = new RelayCommand(param => SubmitExecute(), param => CanSubmitExecute());
                }
                return submit;
            }
        }

        private void SubmitExecute()
        {
            lv.Login(view.usernameBox.Text, view.passwordBox.Password, view);
            view.passwordBox.Clear();
        }

        private bool CanSubmitExecute()
        {
            if (String.IsNullOrEmpty(view.usernameBox.Text) || String.IsNullOrEmpty(view.passwordBox.Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
