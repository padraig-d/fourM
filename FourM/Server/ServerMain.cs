using System;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace FourM.Server
{
    public class ServerMain : BaseScript
    {
        public static int WeaponDrops { get; set; }
        public ServerMain()
        {
            EventHandlers["onResourceStart"] += new Action<string>(OnResourceStart);
        }
        public void OnResourceStart(string resourceName) 
        {
            if (GetCurrentResourceName() != resourceName) return;

            TriggerClientEvent("chat:addMessage", new
			{
				color = new[] { 255, 0, 0 },
				args = new[] { $"Server Started" }
			});	

        }
        
    }
}
