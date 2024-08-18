using CitizenFX.Core;
using CitizenFX.Core.Native;
using static CitizenFX.Core.Native.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResource.Client
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
