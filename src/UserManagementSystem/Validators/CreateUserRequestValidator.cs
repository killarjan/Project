using FluentValidation;
using System.Text.RegularExpressions;
using UserManagementSystem.Models.Users.Requests;

namespace UserManagementSystem.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Age).InclusiveBetween(18, 100);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.PhoneNumber)
                .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")       
                .MaximumLength(20).WithMessage("PhoneNumber must not exceed 20 characters.")
                .Matches(new Regex(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$")).WithMessage("PhoneNumber not valid");
        }
    }
}
