using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MedicalInstitutionApp.Validation
{
    class PasswordValidation
    {
        public bool PasswordCheck(string password)
        {
            Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]){8}$");
            Match match = regex.Match(password);
            return match.Success;            
        }
    }
}
