using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class DeleteEquipmentPositionHistoryValidator : AbstractValidator<DeleteEquipmentPositionHistoryRequest>
    {
        public DeleteEquipmentPositionHistoryValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}
