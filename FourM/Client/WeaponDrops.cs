using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
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
            EventHandlers["fourM:Client:DropWeaponCommand"] += new Action(() => _ = DropWeaponCommandAsync());
            EventHandlers["fourM:Client:JSONDrop"] += new Action(() => _ = JsonDropAsync());
        }

        private async Task DropWeaponCommandAsync()
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

            await CreatePickup(testWeapon);

            PrintChatMessage($"Weapon Dropped! Pickup: {testWeapon.Pickup}");
        }

        private async Task JsonDropAsync()
        {
            IList<WeaponPickup> weaponDrops = new List<WeaponPickup>();

            string file = LoadResourceFile(GetCurrentResourceName(), "weapondrops.json");
            if (string.IsNullOrWhiteSpace(file))
            {
                Debug.WriteLine("Failed to load weapondrops.json");
                return;
            }

            try
            {
                JObject weaponPickupsFile = JObject.Parse(file);
                JArray weaponPickupsJArray = (JArray)weaponPickupsFile["weaponDrops"];

                foreach (JToken weaponPickup in weaponPickupsJArray)
                {
                    weaponDrops.Add(new WeaponPickup(
                        weaponPickup.Value<string>("name"),
                        weaponPickup.Value<int>("id"),
                        weaponPickup.Value<float>("x"),
                        weaponPickup.Value<float>("y"),
                        weaponPickup.Value<float>("z"),
                        weaponPickup.Value<uint>("hash"),
                        weaponPickup.Value<int>("ammo"),
                        weaponPickup.Value<int>("blip")
                    ));

                    Debug.WriteLine(weaponDrops[weaponDrops.Count - 1].Name);
                }

                foreach (WeaponPickup weaponDrop in weaponDrops)
                {
                    RequestModel(weaponDrop.Hash);
                    while (!HasModelLoaded(weaponDrop.Hash))
                    {
                        await Delay(100);
                    }

                    await CreatePickup(weaponDrop);
                }
            }
            catch (JsonException ex)
            {
                Debug.WriteLine("Failed to read file: " + ex.Message);
            }
        }
    }
}
