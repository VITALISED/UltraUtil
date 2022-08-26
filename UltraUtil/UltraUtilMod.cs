using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraUtil.Cheats;
using ULTRAKILL.Cheats;
using BepInEx;
using UnityEngine.SceneManagement;

namespace UltraUtil
{
    public class UltraUtilMelonMod : MelonMod
    {
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            try
            {
                CreateCheats.RegisterCustomCheats();
            }
            catch (Exception e)
            {
                return;
            }
        }
    }

    [BepInPlugin("com.vitalised.ultrautil", "UltraUtil", "0.0.0.1")]
    public class UltraUtilBepInEx : BaseUnityPlugin
    {
        private void Awake()
        {
            try
            {
                CreateCheats.RegisterCustomCheats();
            }
            catch (Exception e)
            {
                return;
            }
        }
    }
}
