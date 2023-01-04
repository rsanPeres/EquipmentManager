using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class CreateEquipmentPositionHistoryValidator : AbstractValidator<CreateEquipmentPositionHistoryRequest>
    {
        public CreateEquipmentPositionHistoryValidator()
        {
            RuleFor(p => p.Length)
                .NotNull()
                .NotEmpty();
            RuleFor(p => p.Latitude)
                .NotNull()
                .NotEmpty();
        }
    }
}
