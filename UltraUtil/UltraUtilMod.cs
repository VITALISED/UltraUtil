using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraUtil.Cheats;
using ULTRAKILL.Cheats;

namespace UltraUtil
{
    public class UltraUtilMod : MelonMod
    {
        static bool loaded = false;

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            try
            {
                RegisterCustomCheats();
            }
            catch (Exception e)
            {
                return;
            }
        }

        void RegisterCustomCheats()
        {
            MonoSingleton<CheatsManager>.Instance.RegisterCheats(new ICheat[3]
            {
                (ICheat)new DebugRoom(),
                (ICheat)new Godmode(),
                (ICheat)new Hitlog()
            }, "ultrautil");

            MonoSingleton<CheatsManager>.Instance.RebuildMenu();
        }
    }
}
