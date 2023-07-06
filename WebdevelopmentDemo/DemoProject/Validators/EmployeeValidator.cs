using DemoProject.Models;
using FluentValidation;

namespace DemoProject.Validators
{
    public class EmployeeValidator:AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.FirstName).NotEmpty().Length(2,20);
            RuleFor(e => e.LastName).NotEmpty().Length(2,20);
            RuleFor(e => e.Email).EmailAddress();
            RuleFor(e => e.JoiningDate).LessThan(DateTime.Now);
            RuleFor(e => e.DateOfBirth).LessThan(DateTime.Now);
        }
    }
}
