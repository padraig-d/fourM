using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using Mono.CSharp;
using static CitizenFX.Core.Native.API;
using static FourM.Client.HelperFunctions;

namespace FourM.Client
{
    public class ClientMain : BaseScript
    {
        public ClientMain()
        {   
            Debug.WriteLine("Hi from FourM.Client!");
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
            EventHandlers["onClientResourceStop"] += new Action<string>(OnClientResourceStop);
        }

        [Tick] // adds to Tick event queue, on every Tick it runs every single function marked with [Tick]
        public async Task OnTick()
        {   
            await Task.FromResult(0);
        }

        [Tick]
        // public async Task TickChat() 
        // {
        //     await Delay(1000);
        //     PrintChatMessage("Hey");
        // }

        private void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;
            
            RegisterCommand("testcountdown", new Action<int>((source) =>
            {
                TriggerServerEvent("fourM:Server:Play30sCountdown");
            }), false);

            RegisterCommand("testpickup", new Action<int>((source) =>
            {
                TriggerEvent("fourM:Client:DropWeaponCommand");
            }), false);

            RegisterCommand("tp", new Action<int, List<object>, string>((source, args, raw) =>
            {
                TriggerEvent("Teleport", args);
            }), false);

            RegisterCommand("coords", new Action<int>((source) =>
            {
                TriggerEvent("Coordinates");
            }), false);

            RegisterCommand("jsondrop", new Action<int>((source) =>
            {
                TriggerServerEvent("fourM:Server:JSONDrop");
            }), false);    


        }
        private void OnClientResourceStop(string resourceName) {
            Tick -= OnTick;
        }
    }

}

