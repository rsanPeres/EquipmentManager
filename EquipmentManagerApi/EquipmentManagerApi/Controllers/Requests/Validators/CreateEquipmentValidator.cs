using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class CreateEquipmentValidator : AbstractValidator<CreateEquipmentRequest>
    {
        public CreateEquipmentValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}
