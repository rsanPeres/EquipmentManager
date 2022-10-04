using Flunt.Notifications;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManager.Domain.Entities
{
    public class EquipmentStateHistory
    {
        public int Id { get; private set; }
        public DateTime ReportedStatusStartDate { get; private set; }
        public int EquipmentId { get; private set; }
        public Equipment Equipment { get; private set; }
        public int EquipmentStateId { get; private set; }
        public EquipmentState EquipmentState { get; private set; }
    }
}
