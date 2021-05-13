using System;
using UnityEngine;

namespace EndlessRunning
{
    public class FightingSystem : MonoBehaviour
    {
        public event Action OnFightHit;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "FightTrigger")
            {
                OnFightHit?.Invoke();
            }
        }
    }
}

