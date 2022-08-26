using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UnityEngine;
using System.IO;
using System.Threading;

namespace UltraUtil.Cheats
{
    public class Screenshot : ICheat
    {
        private bool active;
        public string LongName => nameof(Screenshot);
        public string Identifier => "ultrautil.screenshot";
        public string ButtonEnabledOverride { get; }
        public string ButtonDisabledOverride
        {
            get
            {
                return "Take";
            }
        }
        public string Icon => "flight";
        public bool IsActive => this.active;
        public bool DefaultState { get; }
        public StatePersistenceMode PersistenceMode => StatePersistenceMode.NotPersistent;
        private static Thread thread1, thread2;


        public void Enable()
        {
            this.active = true;

            thread1 = new Thread(Guh2);
            thread1.Start();
            Disable();
        }

        public void Guh2()
        {
            var manager = MonoSingleton<PrefsManager>.Instance;

            HUDOptions hud = MonoSingleton<HUDOptions>.Instance;

            int crosshairType = manager.GetInt("crossHair");
            int hudType = manager.GetInt("hudType");
            //styleMeter = PlayerPrefs.GetInt("StyMet") == 1;
            foreach (BossHealthBar bhb in UnityEngine.Object.FindObjectsOfType<BossHealthBar>())
            {
                bhb.enabled = false;
            }

            MelonLoader.MelonLogger.Msg(crosshairType + " crosshair");
            MelonLoader.MelonLogger.Msg(hudType + " hud");

            hud.CrossHairType(0);
            hud.HudType(0);
            hud.StyleMeter(false);
            hud.StyleInfo(false);
            hud.gameObject.SetActive(false);

            Thread.Sleep(50);

            var folder = Path.GetFullPath(Path.Combine(Path.Combine(Application.dataPath, @"../"), @"Screenshots"));
            var path = Path.Combine(folder, @"Screenshot_" + System.DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".png");
            Directory.CreateDirectory(folder);
            ScreenCapture.CaptureScreenshot(path, 2);

            Thread.Sleep(50);

            hud.CrossHairType(crosshairType);

            manager.SetInt("hudType", hudType);

            thread2 = new Thread(Guh);
            thread2.Start();

            hud.StyleMeter(true);
            hud.StyleInfo(true);
            hud.gameObject.SetActive(true);
            thread2.Join();
        }

        public void Guh()
        {
            Thread.Sleep(150);
            var manager = MonoSingleton<PrefsManager>.Instance;

            HUDOptions hud = MonoSingleton<HUDOptions>.Instance;
            hud.HudType(manager.GetInt("hudType"));
        }

        public void Disable()
        {
            this.active = false;
        }

        public void Update()
        { }
    }
}
