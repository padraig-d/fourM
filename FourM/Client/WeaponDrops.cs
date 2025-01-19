using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CitizenFX.Core;
using FourM.Client;
using Mono.CompilerServices.SymbolWriter;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static CitizenFX.Core.Native.API;
using static FourM.Client.HelperFunctions;

namespace FourM.Client
{
	public class WeaponPickupHelper : BaseScript {
		public void createPickup(WeaponPickup weapon) {

			int pickup = ObjToNet(CreateAmbientPickup(weapon.Hash, weapon.X , weapon.Y, weapon.Z, 1, weapon.Ammo, 2, false, true));
			weapon.Pickup = pickup;

			TriggerServerEvent("fourM:Server:AddBlip", weapon.Pickup, weapon.Blip);
		}
	}

    public class WeaponDrops : BaseScript
    {
        public WeaponDrops()
        {		
            EventHandlers["fourM:Client:DropWeapon"] += new Action(DropWeapon);
			EventHandlers["fourM:Client:DropWeaponCommand"] += new Action(DropWeaponCommand);
			EventHandlers["fourM:Client:JSONDrop"] += new Action(JSONDrop);
        }

        private void DropWeaponCommand() // /testpickup to run in game
        {	
			float x = Game.PlayerPed.Position.X + 2;
			float y = Game.PlayerPed.Position.Y; 
			float z = Game.PlayerPed.Position.Z;

			WeaponPickupHelper helper = new WeaponPickupHelper();
			WeaponPickup testWeapon = new WeaponPickup("deagle", 1, x, y, z, 1817941018, 9, 156);
			
			helper.createPickup(testWeapon);
			PrintChatMessage($"Weapon Dropped! Pickup: {testWeapon.Pickup}");
		}

		private async void DropWeapon()  // /serverpickup
        {
            RequestModel(1817941018);
            while (HasModelLoaded(1817941018))
            {
                await Delay(100);
            }

            int pickup1 = ObjToNet(CreateAmbientPickup(978070226, 13 , 12, 71, 1, 1, 2, false, true));
			TriggerServerEvent("fourM:Server:AddBlip", pickup1, 156);

			int pickup2 = ObjToNet(CreateAmbientPickup(1817941018, 7 , 28, 71, 1, 1, 2, false, true));
			TriggerServerEvent("fourM:Server:AddBlip", pickup2, 156);

			int pickup3 = ObjToNet(CreateAmbientPickup(1817941018, 40 , 17, 70, 1, 1, 2, false, true));
			TriggerServerEvent("fourM:Server:AddBlip", pickup3, 156);	

			int pickup4 = ObjToNet(CreateAmbientPickup(1817941018, 53 , 13, 69.2f, 1, 1, 2, false, true));
			TriggerServerEvent("fourM:Server:AddBlip", pickup4, 156);			
			
			PrintChatMessage($"DropWeapon() ran");
		}

		private async void JSONDrop() // /jsondrop
        {
			IList<WeaponPickup> listWeaponDrop = new List<WeaponPickup>();
			WeaponPickupHelper helper = new WeaponPickupHelper();
		
			string file = LoadResourceFile(GetCurrentResourceName(), "weapondrops.json") ?? "Didn't load";
			dynamic weaponPickupsFile = JsonConvert.DeserializeObject(file);
			try
			{
				JArray weaponPickupsJArray = (JArray)weaponPickupsFile["weaponDrops"];
				foreach (dynamic weaponPickup in weaponPickupsJArray)
				{
					listWeaponDrop.Add(new WeaponPickup(
						Convert.ToString(weaponPickup["name"]),
						Convert.ToInt32(weaponPickup["id"]),
						(float)Convert.ToDouble(weaponPickup["x"]),
						(float)Convert.ToDouble(weaponPickup["y"]),
						(float)Convert.ToDouble(weaponPickup["z"]),
						Convert.ToUInt32(weaponPickup["hash"]),
						Convert.ToInt32(weaponPickup["ammo"]),
						Convert.ToInt32(weaponPickup["blip"])
						));

					Debug.WriteLine(listWeaponDrop[listWeaponDrop.Count - 1].Name);
				}

				foreach (WeaponPickup weaponDrop in listWeaponDrop)
				{
					RequestModel(weaponDrop.Hash);
					while (HasModelLoaded(weaponDrop.Hash))
					{
						await Delay(100);
					}

					helper.createPickup(weaponDrop);
				}

			}
			catch (JsonReaderException ex)
			{
				Debug.WriteLine("Failed to read file: " + ex.Message);
			
			}

		}

    }
}

