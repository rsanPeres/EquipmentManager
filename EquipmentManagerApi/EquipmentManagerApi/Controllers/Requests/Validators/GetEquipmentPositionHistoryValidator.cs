using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class GetEquipmentPositionHistoryValidator : AbstractValidator<GetEquipmentPositionHistoryRequest>
    {
        public GetEquipmentPositionHistoryValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}
