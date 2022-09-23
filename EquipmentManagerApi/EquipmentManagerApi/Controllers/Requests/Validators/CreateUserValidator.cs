using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {

        public CreateUserValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Cpf)
                .NotNull()
                .IsValidCPF()
                .MaximumLength(11)
                .MinimumLength(11)
                .NotEmpty();

            RuleFor(p => p.Role)
                .NotEmpty()
                .NotEmpty();

            RuleFor(p => p.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(p => p.UserName)
                 .NotNull()
                 .NotEmpty();

        }
    }
}
