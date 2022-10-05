using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class GetEquipmentModelValidator : AbstractValidator<GetEquipmentModelRequest>
    {
        public GetEquipmentModelValidator()
        {
            RuleFor(p => p.ModelName)
                .NotNull()
                .NotEmpty();
        }
    }
}
