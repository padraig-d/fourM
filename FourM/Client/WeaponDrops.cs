using System;
using System.Collections.Generic;
using CitizenFX.Core;
using Mono.CompilerServices.SymbolWriter;
using static CitizenFX.Core.Native.API;

namespace FourMNameClient
{
    public class WeaponDrop : BaseScript
    {
        public WeaponDrop()
        {
            EventHandlers["DropWeapon"] += new Action(DropWeapon);
        }
        private void DropWeapon() // /testpickup to run in game
        {	

				  // HOW THE FUCK DO I FIND THESE?????
				  // had to dig through a random github to find it :(
		float x = Game.PlayerPed.Position.X + 2;
		float y = Game.PlayerPed.Position.Y; 
		float z = Game.PlayerPed.Position.Z;
	
								  // deagle hash
		int pickup = CreatePickup(1817941018, x , y, z, 1, 0, true, 0);
		SetBlipSprite(AddBlipForPickup(pickup), 156);
										     // ^ pistol blip
    
		TriggerEvent("chat:addMessage", new
			{
				color = new[] { 255, 0, 0 },
				args = new[] { $"Server command ran!" }
			});	

		}
    }
}