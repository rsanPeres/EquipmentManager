using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class LoginUserValidator : AbstractValidator<LoginUserRequest>
    {
        public LoginUserValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(8);
        }
    }
}
