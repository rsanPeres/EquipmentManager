using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class GetEquipmentModelStateHourlyEarningValidator : AbstractValidator<GetEquipmentModelStateHourlyEarningRequest>
    {
        public GetEquipmentModelStateHourlyEarningValidator()
        {
            RuleFor(x => x.EquipmentModelId).Empty();
            RuleFor(x => x.EquipmentStateId).Empty();
        }
    }
}
