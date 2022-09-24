using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManager.Domain.Entities
{
    public class EquipmentModelStateHourlyEarning : Notifiable<Notification> 
    {
        public int EquipmentModelId { get; set; }
        public EquipmentModel EquipmentModel { get; set; }
        public int EquipmentStateId { get; set; }
        public EquipmentState EquipmentState { get; set; }
        public Decimal EarnedValueByHourState { get; set; }
    }
}
