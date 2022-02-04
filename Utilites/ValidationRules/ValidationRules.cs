using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Utilites.ValidationRules
{


    class EMailValidationRules: ValidationRule
    {
        //asdasdasd34234.asdfasdfasdfasdf234.asasdasd324@asdfsadf_-.ewrt345.53234dsfg.tetre
        private Regex regex = new Regex(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$");
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string email = value.ToString();
            if (regex.IsMatch(email)) return new ValidationResult(true, null);
            else return new ValidationResult(false, "Не правильный адрес");


        }
    }
}
