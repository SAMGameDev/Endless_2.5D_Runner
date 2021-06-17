using UnityEngine;
using System.Collections.Generic;

namespace EndlessRunning
{
    public class FightingSystem : MonoBehaviour
    {
        public bool FightMod;
        [Space(15)] public List<Collider> ragdollColliders = new List<Collider>();

        private void Awake()
        {
            FightMod = false;
            SetRagdollParts();
        }

        private void SetRagdollParts()
        {
            Collider[] colliders = gameObject.GetComponentsInChildren<Collider>();

            foreach (var item in colliders)
            {
                if (item.gameObject != gameObject)
                {
                    item.isTrigger = true;
                    ragdollColliders.Add(item);
                }
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "FightTrigger")
            {
                FightMod = true;
            }
        }
    }
}

