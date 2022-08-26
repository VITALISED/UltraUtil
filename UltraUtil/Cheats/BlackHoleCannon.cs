using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULTRAKILL.Cheats;
using UnityEngine;

namespace UltraUtil.Cheats
{
    public class BHCannon : ICheat
    {
        private bool active;
        public BlackHoleCannon blackHoleCannon;
        public string LongName => "BHCannon";
        public string Identifier => "ultrautil.bhcannon";
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

        }
    }
}
