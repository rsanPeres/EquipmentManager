using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class DeleteEquipmentValidator : AbstractValidator<DeleteEquipmentRequest>
    {
        public DeleteEquipmentValidator()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}
