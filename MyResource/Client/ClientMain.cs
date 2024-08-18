using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace MyResource.Client
{
    public class ClientMain : BaseScript
    {
        public ClientMain()
        {
            Debug.WriteLine("Hi from MyResource.Client!");
        }

        [Tick]
        public Task OnTick()
        {
            return Task.FromResult(0);
        }
    }
}