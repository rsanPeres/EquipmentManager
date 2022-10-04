using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManager.Domain.Entities
{
    public class EquipmentModel : Notifiable<Notification>
    {

        public int Id { get; private set; }
        public string ModelName { get; private set; }
        public ICollection<Equipment> Equipments { get; private set; }
        public ICollection<EquipmentModelStateHourlyEarning> EquipmentsStateHourlyEarning { get; private set; }
        

        public EquipmentModel(string modelname)
        {
            if (string.IsNullOrEmpty(modelname))
            {
                AddNotification("ModelName", "Invalid modelName");
            }
            ModelName = modelname;
            Equipments = new List<Equipment>();
            EquipmentsStateHourlyEarning = new List<EquipmentModelStateHourlyEarning>();
        }

        public void setModelName(string name)
        {
            this.ModelName = name;
        }
    }
}
