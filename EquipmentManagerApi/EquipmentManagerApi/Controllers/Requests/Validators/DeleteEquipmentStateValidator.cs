using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class DeleteEquipmentStateValidator : AbstractValidator<DeleteEquipmentStateRequest>
    {
        public DeleteEquipmentStateValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}
