using FluentValidation;
using WebdevelopmentDemo.Models;

namespace WebdevelopmentDemo.Validation
{
    public class FluentValidationClass :AbstractValidator<Product>
    {
        public FluentValidationClass()
        {
            RuleFor(p => p.Name).NotEmpty().Length(3, 9).WithMessage("Length Must be greater than 3  and less then 9");
        }
    }
}
