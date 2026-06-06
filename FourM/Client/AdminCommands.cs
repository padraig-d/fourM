using System;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;



namespace FourM.Client
{
    public class AdminCommands : BaseScript
    {
        public AdminCommands()
        {
            EventHandlers["Teleport"] += new Action<List<object>>(Teleport);
            EventHandlers["Coordinates"] += new Action(Coordinates);
            EventHandlers["fourM:Client:TestEvent"] += new Action(TestEvent);
        }
        private void Teleport(List<object> args) // /tp
        {	
            if (args.Count < 3 ||
                !float.TryParse(args[0]?.ToString(), out float x) ||
                !float.TryParse(args[1]?.ToString(), out float y) ||
                !float.TryParse(args[2]?.ToString(), out float z))
            {
                TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    args = new[] { "Usage: /tp <x> <y> <z>" }
                });

                return;
            }

            StartPlayerTeleport(PlayerId(), x, y, z, 0, true, true, true);
		}

        private void Coordinates() // /coords
        {	
            float x = Game.PlayerPed.Position.X;
            float y = Game.PlayerPed.Position.Y; 
            float z = Game.PlayerPed.Position.Z;
            TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    args = new[] { $"X={x} Y={y} Z={z}" }
                });	
            }

		private void TestEvent()
        {	
			int player = Game.Player.ServerId;

			TriggerEvent("chat:addMessage", new
			{
				color = new[] { 255, 0, 0 },
				args = new[] { $"PlayerID{player}" }
			});	

		}		        
    }
}
