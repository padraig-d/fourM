using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace FourM.Client
{
    public static class HelperFunctions {
        
        public static void PrintChatMessage(string input) {
            			
			CitizenFX.Core.BaseScript.TriggerEvent("chat:addMessage", new
				{
					color = new[] { 255, 0, 0 },
					args = new[] { input }
				});	
        }

        public static void PrintDebugMessage(string input) {
            Debug.WriteLine(input);
        }

        public static async Task<Prop> CreatePickup(WeaponPickup weapon) {

			Prop pickup = await World.CreateAmbientPickup((PickupType)weapon.Hash, weapon.Position, weapon.Name , weapon.Ammo);
            weapon.Pickup = pickup;

            Blip weaponBlip = pickup.AttachBlip();
            weaponBlip.Sprite = (BlipSprite)weapon.Blip;

			CitizenFX.Core.BaseScript.TriggerServerEvent("fourM:Server:AddBlip", NetworkGetNetworkIdFromEntity(pickup.Handle), weapon.Blip);

            return pickup;
		}

    }
}


