﻿using EquipmentManager.Domain.Entities;

namespace EquipmentManagerApi.Controllers.Requests
{
    public class GetEquipmentStateHistoryRequest
    {
        public int Id { get; set; }
        public GetEquipmentStateRequest EquipmentState { get; set; }
    }
}
