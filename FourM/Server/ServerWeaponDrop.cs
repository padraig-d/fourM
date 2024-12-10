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
            EventHandlers["fourM:Server:AddBlip"] += new Action<int, int>(AddBlip);
            //EventHandlers["OnResourceStart"] += new Action(DropWeapon);
            EventHandlers["fourM:Server:DropWeapon"] += new Action(DropWeapon);
            EventHandlers["fourM:Server:JSONDrop"] += new Action(JSONDrop);
        }

        private void AddBlip(int pickup, int blip)
        {
            int networkPickup = NetworkGetEntityFromNetworkId(pickup);
            //Debug.WriteLine(networkPickup.ToString());
            SetBlipSprite(AddBlipForEntity(networkPickup), blip);
        }

        private void DropWeapon() // /serverpickup
        {   
            Player player = Players.First();
            player.TriggerEvent("fourM:Client:DropWeapon");
        }

        private void JSONDrop() // /jsondrop
        {   
            Player player = Players.First();
            player.TriggerEvent("fourM:Client:JSONDrop");
        }
    }
}
