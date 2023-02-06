using FluentValidation;
using UserManagementSystem.Models.Users.Requests;

namespace UserManagementSystem.Validators
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.Age).InclusiveBetween(18, 100);
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
