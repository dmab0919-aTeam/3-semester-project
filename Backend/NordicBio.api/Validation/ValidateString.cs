using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordicBio.api.Validation
{
    public class ValidateString
    {
        public ValidateString(string input, string regex, string message)
        {
            Input = input;
            Regex = regex;
            Message = message;
        }

        public string Input { get; set; }
        public string Regex { get; set; }
        public string Message { get; set; }
    }
}
