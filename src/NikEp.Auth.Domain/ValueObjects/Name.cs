using System.Text.RegularExpressions;

namespace NikEp.Auth.Domain.ValueObjects
{
    public class Name
    {
        private static string _value { get; set; }
        private Name(string value) 
        {
            _value = value;
        }

        //public static Name Create(string first, string last)
        //{
        //    Regex regex = new Regex(@"^[А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+$");
        //    if (!String.IsNullOrEmpty(string.Concat(first, last).Trim()) & regex.IsMatch(first) & regex.IsMatch(last))
        //    {
        //        return new Name(first, last);
        //    }
        //    else throw new ArgumentException();
        //}
        public static (bool IsSucsess, string Message, Name Value) Create(string value)
        {
           
            Regex regex = new Regex(@"^[А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+$");
            if (String.IsNullOrEmpty(value)) return (false, "You entered an empty name", null);
            if(!regex.IsMatch(value.Trim())) return (false, "It is allowed to specify letters of English or Russian " +
                    "languages and numbers", null);
            _value = value;
            return (true, "Successfully", new Name(_value));
        }

    }
}
