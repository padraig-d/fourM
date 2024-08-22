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
		float x = Game.PlayerPed.Position.X + 2;
		float y = Game.PlayerPed.Position.Y; 
		float z = Game.PlayerPed.Position.Z;
	
								  // deagle hash
		int pickup = CreateAmbientPickup(1817941018, x , y, z, 1, 1, 2, false, true);
		SetBlipSprite(AddBlipForEntity(pickup), 156);
										     // ^ pistol blip
	
		//ApplyForceToEntity(pickup, 3, 100, 100, 1, 100, 1, 1, 0, false, true, true, false, true);

		TriggerEvent("chat:addMessage", new
			{
				color = new[] { 255, 0, 0 },
				args = new[] { $"Weapon Dropped!{pickup}" }
			});	

		}

		// private void DropWeapon()
        // {	
		// int pickup1 = CreateAmbientPickup(1817941018, 13 , 12, 71, 1, 1, 2, false, true);
		// SetBlipSprite(AddBlipForEntity(pickup1), 156);

		// int pickup2 = CreateAmbientPickup(1817941018, 7 , 28, 71, 1, 1, 2, false, true);
		// SetBlipSprite(AddBlipForEntity(pickup2), 156);

		// int pickup3 = CreateAmbientPickup(1817941018, 40 , 17, 70, 1, 1, 2, false, true);
		// SetBlipSprite(AddBlipForEntity(pickup3), 156);		

		// int pickup4 = CreateAmbientPickup(1817941018, 53 , 13, 69.2f, 1, 1, 2, false, true);
		// SetBlipSprite(AddBlipForEntity(pickup4), 156);				

		// TriggerEvent("chat:addMessage", new
		// {
		// 	color = new[] { 255, 0, 0 },
		// 	args = new[] { $"DropWeapon() ran" }
		// });	

		}
    }

