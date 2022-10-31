using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class DeleteEquipmentModelStateHourlyEarningValidator : AbstractValidator<DeleteEquipmentModelStateHourlyEarningRequest>
    {
        public DeleteEquipmentModelStateHourlyEarningValidator()
        {
            RuleFor(x => x.EquipmentModelId).Empty();
            RuleFor(x => x.EquipmentStateId).Empty();
        }
    }
}
