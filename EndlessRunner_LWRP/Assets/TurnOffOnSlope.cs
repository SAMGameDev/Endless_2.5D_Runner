using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class TurnOffOnSlope : MonoBehaviour
    {
        public CharacterControl Ccontrol;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.isTrigger && other.gameObject.CompareTag("Player"))
            {
                Ccontrol.isOnSlope = false;
            }
        }
    }
}

