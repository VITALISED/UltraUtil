using System;
using System.Collections.Generic;
using System.Linq;
using ULTRAKILL.Cheats;
using UnityEngine;

namespace UltraUtil.Cheats
{
    public class Greenscreen : ICheat
    {
        private bool active;
        public string LongName => nameof(Greenscreen);
        public string Identifier => "ultrautil.greenscreen";
        public string ButtonEnabledOverride { get; }
        public string ButtonDisabledOverride { get; }
        public string Icon => "flight";
        public bool IsActive => this.active;
        public bool DefaultState { get; }
        public StatePersistenceMode PersistenceMode => StatePersistenceMode.NotPersistent;

        public List<GameObject> objs;

        public void Enable()
        {
            this.active = true;
            objs = new List<GameObject>();

            objs.Add(GameObject.Find("Cube (1)"));
            objs.Add(GameObject.Find("Cube (2)"));
            objs.Add(GameObject.Find("Cube (3)"));
            objs.Add(GameObject.Find("Cube (5)"));

            foreach(GameObject obj in objs)
            {
                MeshRenderer thing = obj.GetComponent(typeof(MeshRenderer)) as MeshRenderer;

                thing.material.color = new Vector4(0.01f, 0.98f, 0.01f, 1f);
                thing.material.mainTextureScale = new Vector2(100000f, 100000f);
            }
        }

        public void Disable()
        { }

        public void Update()
        { }
    }
}
