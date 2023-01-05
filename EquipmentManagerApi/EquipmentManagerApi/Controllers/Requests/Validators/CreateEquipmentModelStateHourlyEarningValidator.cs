using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class CreateEquipmentModelStateHourlyEarningValidator : AbstractValidator<CreateEquipmentModelStateHourlyEarningRequest>
    {
        public CreateEquipmentModelStateHourlyEarningValidator()
        {
            RuleFor(x => x.EarnedValueByHourState)
                .NotEmpty();
            RuleFor(x => x.EquipmentModelId).NotEmpty();
            RuleFor(x => x.EquipmentStateId).NotEmpty();
        }
    }
}
