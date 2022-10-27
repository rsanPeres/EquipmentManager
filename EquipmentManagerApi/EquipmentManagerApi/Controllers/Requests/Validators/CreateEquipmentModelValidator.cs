using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class CreateEquipmentModelValidator : AbstractValidator<CreateEquipmentModelRequest>
    {
        public CreateEquipmentModelValidator()
        {
            RuleFor(p => p.ModelName)
                .NotNull()
                .NotEmpty();
        }
    }
}
