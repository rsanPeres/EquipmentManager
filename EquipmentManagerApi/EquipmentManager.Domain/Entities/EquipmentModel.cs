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
        public string Name { get; set; }
        public ICollection<Equipment> Equipments { get; private set; }//Todo:Collection não inicializada
        public ICollection<EquipmentModelStateHourlyEarning> EquipmentsStateHourlyEarning { get; private set; }
        

        public EquipmentModel(string name)
        {
            Name = name;
        }
    }
}
