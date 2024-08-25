using System;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace FourM.Server
{
    public class ServerMain : BaseScript
    {
        public static int WeaponDrops { get; set; }
        public ServerMain()
        {
            Debug.WriteLine("Hi from FourM.Server!");
        }

        [Command("hello_server")]
        public void HelloServer()
        {
            Debug.WriteLine("Sure, hello.");
        }
    }
}