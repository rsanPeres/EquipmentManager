using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class GetEquipmentStateValidator : AbstractValidator<GetEquipmentStateRequest>
    {
        public GetEquipmentStateValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}
