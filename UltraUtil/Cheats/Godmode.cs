using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULTRAKILL.Cheats;
using UnityEngine;

namespace UltraUtil.Cheats
{
    public class Godmode : ICheat
    {
        private bool active;
        public string LongName => nameof(Godmode);
        public string Identifier => "ultrautil.godmode";
        public string ButtonEnabledOverride { get; }
        public string ButtonDisabledOverride { get; }
        public string Icon => "flight";
        public bool IsActive => this.active;
        public bool DefaultState { get; }
        public StatePersistenceMode PersistenceMode => StatePersistenceMode.NotPersistent;

        public void Enable()
        {
            this.active = true;
        }

        public void Disable()
        {
            this.active = false;
        }

        public void Update()
        {
            MonoSingleton<NewMovement>.Instance.hp = 100;
        }
    }
}
