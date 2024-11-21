namespace NikEp.Auth.Domain;

public abstract class Entity<TModel, TValidator>
    where TValidator : Validator<TModel>, new()
{
    public static Validator<TModel> Validator { get; private set; } = new TValidator();

    public Guid Id { get; private set; }

    protected Entity()
    {
        if (Id.Equals(Guid.Empty))
            Id = Guid.NewGuid();
    }
    
    protected Entity(Guid id)
    {
        Id = id;
    }
}