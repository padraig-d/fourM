using CitizenFX.Core;
using System;
using static CitizenFX.Core.Native.API;

namespace FourM.Server
{
    public class ServerWeaponDrop : BaseScript
    {
        public ServerWeaponDrop() 
        {
            EventHandlers["onResourceStart"] += new Action(DropWeapon);                    
            EventHandlers["fourM:Server:AddBlip"] += new Action<int>(AddBlip);

            
        }

        private void AddBlip(int pickup)
        {
            // this doesnt work...my only theory is that this creates a blip that OTHER players see but i think its unlikely...
            AddBlipForEntity(pickup);
            TriggerClientEvent("chat:addMessage", new
			{
				color = new[] { 255, 0, 0 },
				args = new[] { $"Reached Here! Pickup: {pickup}" }
			});	

        }

        private void DropWeapon() {
            if (ServerMain.WeaponDrops != 0) 
            {
                TriggerClientEvent("chat:addMessage", new
			    {
				color = new[] { 255, 0, 0 },
				args = new[] { $"Weapons got dropped already! Returning...{ServerMain.WeaponDrops}" }
			    });	
                return;
            }

            TriggerEvent("fourM:Client:DropWeapon");
            ServerMain.WeaponDrops += 1;

            TriggerClientEvent("chat:addMessage", new
			{
				color = new[] { 255, 0, 0 },
				args = new[] { $"Severside Command Ran" }
			});	

        }
    }
}
