using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class GetEquipmentValidator : AbstractValidator<GetEquipmentRequest>
    {
        public GetEquipmentValidator()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}
