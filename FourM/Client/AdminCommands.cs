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
        }
        private void Teleport(List<object> args) // /tp
        {	
        int player = Game.Player.GetHashCode();

        float x = float.Parse(args[0].ToString());
        float y = float.Parse(args[1].ToString());
        float z = float.Parse(args[2].ToString());

        StartPlayerTeleport(player, x, y, z, 0, true, true, true);
    
		TriggerEvent("chat:addMessage", new
			{
				color = new[] { 255, 0, 0 },
				args = new[] { $"it worked woooooooo!{args[0]}" }
			});	

		}
    }
}