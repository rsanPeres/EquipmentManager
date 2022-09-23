using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class UpdateEquipmentValidator : AbstractValidator<UpdateEquipmentRequest>
    {
        public UpdateEquipmentValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}
