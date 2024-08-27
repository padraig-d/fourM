using System;
using System.Collections.Generic;
using CitizenFX.Core;
using Mono.CompilerServices.SymbolWriter;
using Mono.CSharp;
using static CitizenFX.Core.Native.API;

namespace FourMNameClient
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
            int player = Game.Player.GetHashCode();

            float x = float.Parse(args[0].ToString());
            float y = float.Parse(args[1].ToString());
            float z = float.Parse(args[2].ToString());

            StartPlayerTeleport(player, x, y, z, 0, true, true, true);
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