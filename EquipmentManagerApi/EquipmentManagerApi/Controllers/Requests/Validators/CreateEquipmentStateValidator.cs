using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class CreateEquipmentStateValidator : AbstractValidator<CreateEquipmentStateRequest>
    {
        public CreateEquipmentStateValidator()
        {
            RuleFor(x => x.EquipmentColor)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.StateName)
                .NotEmpty()
                .NotNull();
        }
    }
}
