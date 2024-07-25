
namespace NikEp.Auth.Domain.ValueObjects
{
    public record Age
    {
        public string UserAge { get; } // TODO:добавить валидацию
        public Age(string userAge)
        {
            UserAge = userAge;
        }

    }
}
