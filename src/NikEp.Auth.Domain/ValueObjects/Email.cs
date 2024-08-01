using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NikEp.Auth.Domain.ValueObjects
{
    public record class Email
    {
        private static string _value { get; set; }
        private Email(string value)
        {
            _value = value;
        }

        public static (bool IsSucsess, string Message, Email Value) Create(string value)
        {

            Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@"
                + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            if (String.IsNullOrEmpty(value)) return (false, "You entered an empty Email", null);
            if (!regex.IsMatch(value.Trim())) return (false, "Not a valid email ", null);
            _value = value;
            return (true, "Successfully", new Email(_value));
        }
    }
}

        
