﻿using System.Text.RegularExpressions;

namespace NikEp.Auth.Domain.ValueObjects
{
    public record Name
    {
        public string Value { get; private set; }
        
        public Name(string value) 
        {
            var regex = new Regex(@"/^([а-яё\s]+|[a-z\s]+)$/iu");
            if (String.IsNullOrEmpty(value)) 
                throw new ArgumentException("You entered an empty name");
            if(!regex.IsMatch(value.Trim())) 
                throw new ArgumentException("It is allowed to specify letters of English or Russian " +
                                             "languages and numbers");
            
            Value = value;
        }
    }
}
