using FluentValidation;
using UserManagementSystem.Models.Users.Requests;

namespace UserManagementSystem.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Age).InclusiveBetween(18, 100);
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
