using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraUtil.Cheats;

namespace UltraUtil
{
    public class CreateCheats
    {
        public static void RegisterCustomCheats()
        {
            MonoSingleton<CheatsManager>.Instance.RegisterCheats(new ICheat[6]
            {
                (ICheat)new DebugRoom(),
                (ICheat)new Godmode(),
                (ICheat)new BHCannon(),
                (ICheat)new Greenscreen(),
                (ICheat)new Screenshot(),
                (ICheat)new HideWeapon(),
            }, "ultrautil");

            MonoSingleton<CheatsManager>.Instance.RebuildMenu();
        }
    }
}
