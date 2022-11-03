﻿using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Requests
{
    public class CreateEquipmentModelStateHourlyEarningRequest
    {
        public int EquipmentModelId { get; set; }
        public int EquipmentStateId { get; set; }
        public Decimal EarnedValueByHourState { get; set; }
    }
}
