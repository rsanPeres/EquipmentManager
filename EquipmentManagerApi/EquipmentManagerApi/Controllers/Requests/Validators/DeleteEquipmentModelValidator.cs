﻿using FluentValidation;

namespace EquipmentManagerApi.Controllers.Requests.Validators
{
    public class DeleteEquipmentModelValidator : AbstractValidator<DeleteEquipmentModelRequest>
    {
        public DeleteEquipmentModelValidator()
        {
            RuleFor(p => p.ModelName)
                .NotNull()
                .NotEmpty();
        }
    }
}
