using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class UpdateEquipmentModelValidator : AbstractValidator<UpdateEquipmentModelRequest>
    {
        public UpdateEquipmentModelValidator()
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
