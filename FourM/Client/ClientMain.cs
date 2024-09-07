using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using Mono.CSharp;
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

            RegisterCommand("serverpickup", new Action<int>((source) =>
            {
                TriggerServerEvent("fourM:Server:DropWeapon");
            }), false);           



        }
    }
}

