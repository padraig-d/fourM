using System;
using System.Collections.Generic;
using System.IO;
using CitizenFX.Core;
using FourM.Client;
using Mono.CompilerServices.SymbolWriter;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static CitizenFX.Core.Native.API;

namespace FourMNameClient
{
    public class WeaponDrops : BaseScript
    {
        public WeaponDrops()
        {
			// EventHandlers["onClientResourceStart"] += new Action(DropWeapon);			
            EventHandlers["fourM:Client:DropWeapon"] += new Action(DropWeapon);
			EventHandlers["fourM:Client:DropWeaponCommand"] += new Action(DropWeaponCommand);
			EventHandlers["fourM:Client:JSONDrop"] += new Action(JSONDrop);
        }

        private void DropWeaponCommand() // /testpickup to run in game
        {	

			float x = Game.PlayerPed.Position.X + 2;
			float y = Game.PlayerPed.Position.Y; 
			float z = Game.PlayerPed.Position.Z;

														// deagle hash
			int pickup = ObjToNet(CreateAmbientPickup(1817941018, x , y, z, 1, 1, 2, false, true));
			TriggerServerEvent("fourM:Server:AddBlip", pickup);
			
			TriggerEvent("chat:addMessage", new
				{
					color = new[] { 255, 0, 0 },
					args = new[] { $"Weapon Dropped! Pickup: {pickup}" }
				});	

		}

		private async void DropWeapon()
        {
            RequestModel(1817941018);
            while (HasModelLoaded(1817941018))
            {
                await Delay(100);
            }

            int pickup1 = ObjToNet(CreateAmbientPickup(978070226, 13 , 12, 71, 1, 1, 2, false, true));
			TriggerServerEvent("fourM:Server:AddBlip", pickup1);

			int pickup2 = ObjToNet(CreateAmbientPickup(1817941018, 7 , 28, 71, 1, 1, 2, false, true));
			TriggerServerEvent("fourM:Server:AddBlip", pickup2);

			int pickup3 = ObjToNet(CreateAmbientPickup(1817941018, 40 , 17, 70, 1, 1, 2, false, true));
			TriggerServerEvent("fourM:Server:AddBlip", pickup3);	

			int pickup4 = ObjToNet(CreateAmbientPickup(1817941018, 53 , 13, 69.2f, 1, 1, 2, false, true));
			TriggerServerEvent("fourM:Server:AddBlip", pickup4);			
			

			TriggerEvent("chat:addMessage", new
			{
				color = new[] { 255, 0, 0 },
				args = new[] { $"DropWeapon() ran" }
			});	

		}

		private async void JSONDrop()
        {
			IList<WeaponPickup> listWeaponDrop = new List<WeaponPickup>();
			string file = LoadResourceFile("fourM", "paleto-bay-weapons.json");
			dynamic weaponPickupsFile = JsonConvert.DeserializeObject(file);

			try
			{
				JArray weaponPickupsJArray = (JArray)weaponPickupsFile["weaponDrops"];
				foreach (dynamic weaponPickup in weaponPickupsJArray)
				{
					listWeaponDrop.Add(new WeaponPickup(
                        Convert.ToString(weaponPickup["name"]),
                        Convert.ToInt32(weaponPickup["id"]),
                        Convert.ToDouble(weaponPickup["x"]),
                        Convert.ToDouble(weaponPickup["y"]),
                        Convert.ToDouble(weaponPickup["z"]),
                        Convert.ToUInt32(weaponPickup["pickup"]),
                        Convert.ToInt32(weaponPickup["ammo"]),
                        Convert.ToInt32(weaponPickup["blip"])
                        ));
				}

				foreach (WeaponPickup weaponDrop in listWeaponDrop)
				{
                    RequestModel(weaponDrop.Pickup);
                    while (HasModelLoaded(weaponDrop.Pickup))
                    {
                        await Delay(100);
                    }

                    int pickup = ObjToNet(CreateAmbientPickup(weaponDrop.Pickup, weaponDrop.X, weaponDrop.Y, weaponDrop.Z, 1, 1, 2, false, true));
                    TriggerServerEvent("fourM:Server:AddBlip", pickup);
                }

            }
			catch (Exception ex)
			{
				Debug.WriteLine("Failed to read file: " + ex.Message);
			}
		}

    }
}

