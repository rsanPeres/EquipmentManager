using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserValidator()
        {
            RuleFor(p => p.Cpf)
                .NotNull()
                .IsValidCPF()
                .MaximumLength(11)
                .MinimumLength(11)
                .NotEmpty();
        }
    }
}
