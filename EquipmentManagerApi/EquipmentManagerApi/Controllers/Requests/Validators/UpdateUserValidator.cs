using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {

        public UpdateUserValidator()
        {
            RuleFor(p => p.Cpf)
                .NotNull()
                .IsValidCPF()
                .MaximumLength(11)
                .MinimumLength(11)
                .NotEmpty();

            RuleFor(p => p.Role)
                .NotEmpty()
                .NotEmpty();
        }
    }
}
