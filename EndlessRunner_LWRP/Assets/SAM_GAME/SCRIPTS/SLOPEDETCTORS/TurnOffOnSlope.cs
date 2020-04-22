using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class TurnOffOnSlope : MonoBehaviour
    {
        public CharacterControl Ccontrol;
        private void Awake()
        {
            Ccontrol = GameObject.FindObjectOfType<CharacterControl>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Ccontrol.isOnSlope = false;
            }
            else
            {
                return;
            }
        }
    }
}

