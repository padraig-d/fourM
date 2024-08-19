using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace FourM.Client
{
    public class ClientMain : BaseScript
    {
        public ClientMain()
        {
            Debug.WriteLine("Hi from FourM.Client!");
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }

        [Tick]
        public Task OnTick()
        {
            return Task.FromResult(0);
        }

        private void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;

            RegisterCommand("testcountdown", new Action<int>((source) =>
            {
                TriggerServerEvent("fourM:Server:Play30sCountdown");
            }), false);

            RegisterCommand("testpickup", new Action<int>((source) =>
            {
                TriggerEvent("DropWeapon");
            }), false);
        }
    }
}