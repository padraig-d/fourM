using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CitizenFX.Core;
using FourM.Client;
using Mono.CompilerServices.SymbolWriter;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static CitizenFX.Core.Native.API;
using static FourM.Client.HelperFunctions;

namespace FourM.Client
{
    public class WeaponDrops : BaseScript
    {
        public WeaponDrops()
        {		
			EventHandlers["fourM:Client:DropWeaponCommand"] += new Action(DropWeaponCommand);
			EventHandlers["fourM:Client:JSONDrop"] += new Action(JSONDrop);
        }

        private void DropWeaponCommand() // /testpickup to run in game
        {	
			float x = Game.PlayerPed.Position.X + 2;
			float y = Game.PlayerPed.Position.Y; 
			float z = Game.PlayerPed.Position.Z;

			WeaponPickup testWeapon = new WeaponPickup("W_PI_PISTOL", 1, x, y, z, 4189041807, 120, 156);

			PrintDebugMessage(testWeapon.Name);
			PrintDebugMessage(testWeapon.Id.ToString());
			PrintDebugMessage(testWeapon.Position.ToString());
			PrintDebugMessage(testWeapon.Hash.ToString());
			PrintDebugMessage(testWeapon.Ammo.ToString());
			PrintDebugMessage(testWeapon.Blip.ToString());

			CreatePickup(testWeapon);



			PrintChatMessage($"Weapon Dropped! Pickup: {testWeapon.Pickup}");
		}

		private async void JSONDrop() // /jsondrop
        {
			IList<WeaponPickup> listWeaponDrop = new List<WeaponPickup>();
		
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

					CreatePickup(weaponDrop);
				}

			}
			catch (JsonReaderException ex)
			{
				Debug.WriteLine("Failed to read file: " + ex.Message);
			
			}

		}

    }
}

