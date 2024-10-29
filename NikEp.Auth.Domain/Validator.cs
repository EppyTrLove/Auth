using System.Linq.Expressions;
using FluentValidation;

namespace NikEp.Auth.Domain;

public abstract class Validator<T> : AbstractValidator<T>
{
    public IRuleBuilderOptions<T, TProperty> RulesFor<TProperty>(
        Expression<Func<T, TProperty>> expression, 
        Func<IRuleBuilder<T, TProperty>, IRuleBuilderOptions<T, TProperty>> func) 
    {
        return func.Invoke(RuleFor(expression));
    }
    
    public IRuleBuilderOptions<T, TProperty> RulesFor<TProperty>(
        Expression<Func<T, TProperty>> expression, 
        IValidator<TProperty> validator) 
    {
        return RulesFor(expression, (rb) => rb.SetValidator(validator));
    }
}