using CitizenFX.Core;
using System;
using System.Linq;
using System.Xml.XPath;
using static CitizenFX.Core.Native.API;

namespace FourM.Server
{
    public class ServerWeaponDrop : BaseScript
    {
        public ServerWeaponDrop() 
        {               
            EventHandlers["fourM:Server:AddBlip"] += new Action<int>(AddBlip);
            EventHandlers["fourM:Server:DropWeapon"] += new Action(DropWeapon);
            EventHandlers["fourM:Server:DropWeaponJSON"] += new Action(DropWeaponJSON);
        }

        private void AddBlip(int pickup)
        {
            int networkPickup = NetworkGetEntityFromNetworkId(pickup);
            SetBlipSprite(AddBlipForEntity(networkPickup), 156);
        }

        private void DropWeapon() // /serverpickup
        {   
            Player player = Players.First();
            player.TriggerEvent("fourM:Client:DropWeapon");
        }

        private void DropWeaponJSON() // /pickupJSON
        {   
            Player player = Players.First();
            player.TriggerEvent("fourM:Client:DropWeaponJSON");
        }        
    }
}
