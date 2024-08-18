using CitizenFX.Core;
using System;

namespace MyResource.Server
{
    public class SoundsServer : BaseScript
    {
        public SoundsServer() 
        {
            EventHandlers["fourM:Server:Play30sCountdown"] += new Action(Play30sCountdownToAll);
        }

        private void Play30sCountdownToAll()
        {
            TriggerClientEvent("fourM:Client:Play30sCountdown");
        }
    }
}
