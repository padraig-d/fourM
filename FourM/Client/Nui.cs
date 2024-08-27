using System;
using CitizenFX.Core;
using Newtonsoft.Json;
using static CitizenFX.Core.Native.API;

namespace MyResource.Client
{
    public class Nui : BaseScript
    {
        public Nui()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }

        private void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;
            
            DisplayNui(false);
            
            RegisterCommand("showui", new Action<int>((source) =>
            {
                DisplayNui(true);
            }), false);
            
            RegisterCommand("hideui", new Action<int>((source) =>
            {
                DisplayNui(false);
            }), false);
        }

        private void DisplayNui(bool display)
        {
            SetNuiFocus(display, display);
            string nuiMessage = JsonConvert.SerializeObject(new { type = "display", display = display });
            SendNuiMessage(nuiMessage);
        }
    }
}