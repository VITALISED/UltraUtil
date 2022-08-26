using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UltraUtil.Cheats
{
    public class HideWeapon : ICheat
    {
        private bool active;
        public string LongName => "Hide Weapon";
        public string Identifier => "ultrautil.hideweapon";
        public string ButtonEnabledOverride { get; }
        public string ButtonDisabledOverride { get; }
        public string Icon => "flight";
        public bool IsActive => this.active;
        public bool DefaultState { get; }
        public StatePersistenceMode PersistenceMode => StatePersistenceMode.NotPersistent;

        private GameObject gunControl;

        public void Enable()
        {
            this.active = true;

            gunControl = UnityEngine.Object.FindObjectOfType<GunControl>().gameObject;
            gunControl.SetActive(false);
        }

        public void Disable()
        {
            if (gunControl != null) gunControl.SetActive(true);
            this.active = false;
        }

        public void Update()
        { }
    }
}
