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

        //Todo: Setters públicos?? Isso já foi apontado anteriormente
        public int Id { get; set; }
        public string ModelName { get; set; }
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
    }
}
