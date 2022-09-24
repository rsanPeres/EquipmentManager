using Flunt.Notifications;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManager.Domain.Entities
{
    public class EquipmentStateHistory : Notifiable<Notification>
    {
        public int Id { get; set; }
        public DateTime ReportedStatusStartDate { get; set; }
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        public int EquipmentStateId { get; set; }
        public EquipmentState EquipmentState { get; set; }
    }
}
