using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULTRAKILL.Cheats;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UltraUtil.Cheats
{
    public class DebugRoom : ICheat
    {
        private bool active;
        public string LongName => "Debug Room";
        public string Identifier => "ultrautil.debugroom";
        public string ButtonEnabledOverride { get; }
        public string ButtonDisabledOverride
        {
            get
            {
                return "LOAD";
            }
        }

        public string Icon => "flight";
        public bool IsActive => this.active;
        public bool DefaultState { get; }
        public StatePersistenceMode PersistenceMode => StatePersistenceMode.NotPersistent;

        public void Enable()
        {
            this.active = true;
            SceneManager.LoadScene("DebugRoom");
            MonoSingleton<CheatsManager>.Instance.DisableCheat("ultrautil.debugroom");
        }

        public void Disable()
        {
            this.active = false;
        }

        public void Update()
        { }
    }
}
