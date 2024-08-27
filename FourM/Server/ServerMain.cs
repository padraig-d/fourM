using System;
using System.Threading;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace FourM.Server
{
    public class ServerMain : BaseScript
    {
        public static int WeaponDrops { get; set; }
        public ServerMain()
        {
            EventHandlers["onResourceStart"] += new Action(OnClientResourceStart);
        }
        public void OnClientResourceStart() 
        {
            TriggerClientEvent("chat:addMessage", new
			{
				color = new[] { 255, 0, 0 },
				args = new[] { $"Server Started" }
			});	

        }
    }
}