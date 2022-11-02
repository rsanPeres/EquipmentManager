using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class GetEquipmentStateHistoryValidator : AbstractValidator<GetEquipmentStateHistoryRequest>
    {
        public GetEquipmentStateHistoryValidator()
        {

            RuleFor(p => p.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}
