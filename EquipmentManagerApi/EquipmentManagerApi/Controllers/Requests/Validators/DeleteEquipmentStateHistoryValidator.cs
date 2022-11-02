using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class DeleteEquipmentStateHistoryValidator : AbstractValidator<DeleteEquipmentStateHistoryRequest>
    {
        public DeleteEquipmentStateHistoryValidator()
        {

            RuleFor(p => p.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}
