using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikEp.Auth.Domain.ValueObjects
{
    internal class Age
    {
        public string UserAge { get; } // TODO:добавить валидацию
        public Age(string userAge)
        {
            UserAge = userAge;
        }

    }
}
