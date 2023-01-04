using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {

        public CreateUserValidator()
        {
            RuleFor(p => p.Cpf)
                .NotNull()
                .IsValidCPF()
                .MaximumLength(11)
                .MinimumLength(11)
                .NotEmpty()
                .WithMessage("CPF deve ser informado");

            RuleFor(p => p.Role)
                .NotEmpty()
                .NotEmpty()
                .WithName("Employee Role");

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
