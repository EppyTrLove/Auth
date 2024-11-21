namespace NikEp.Auth.Domain;

public abstract record ValueObject<TModel, TValidator>
    where TValidator : Validator<TModel>, new()
{
    protected static Validator<TModel> Validator { get; private set; } = new TValidator();
}