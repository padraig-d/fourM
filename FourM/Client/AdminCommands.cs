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
            EventHandlers["Teleport"] += new Action<string>(Teleport);
        }
        private void Teleport(string passedText) // /tp
        {	
        // int player = Game.Player.GetHashCode();
        // StartPlayerTeleport(player, 10, 10, 10, 100, true, true, true);
    
		TriggerEvent("chat:addMessage", new
			{
				color = new[] { 255, 0, 0 },
				args = new[] { $"Teleport Ran!{passedText}" }
			});	

		}
    }
}