using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class GetUserValidator : AbstractValidator<GetUserRequest>
    {

        public GetUserValidator()
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
