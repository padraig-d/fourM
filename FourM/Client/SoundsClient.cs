using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using System;

namespace FourM.Client
{
    public class SoundsClient : BaseScript
    {
        public SoundsClient()
        {
            EventHandlers["fourM:Client:Play30sCountdown"] += new Action(Play30sCountdown);
        }

        private void Play30sCountdown()
        {
            TriggerMusicEvent("FM_COUNTDOWN_30S");
        }
    }
}
