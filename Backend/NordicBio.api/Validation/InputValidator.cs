using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NordicBio.api.Validation
{
    public static class InputValidator
    {
        public static List<string> StringInputValidation(List<ValidateString> validations)
        {
            List<string> v = new List<string>();

            for (int i = 0; i < validations.Count; i++)
            {
                if (validations[i].Input != null)
                {
                    Regex regex = new Regex(validations[i].Regex);
                    if (!regex.IsMatch(validations[i].Input))
                    {
                        v.Add(validations[i].Message);
                    }
                } else
                {
                    v.Add("Input must not be empty");
                }
               
            }
            return v;
        }
    }
}
