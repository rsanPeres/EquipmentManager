using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class CreateEquipmentStateHistoryValidator : AbstractValidator<CreateEquipmentStateHistoryRequest>
    {
        public CreateEquipmentStateHistoryValidator()
        {
            
            RuleFor(p => p.ReportedStatusStartDate)
                .NotNull()
                .NotEmpty();
        }
    }
}
