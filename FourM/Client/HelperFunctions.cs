using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using Mono.CSharp;
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

    }
}


