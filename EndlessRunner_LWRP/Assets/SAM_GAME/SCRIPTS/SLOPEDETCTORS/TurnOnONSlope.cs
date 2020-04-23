using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class TurnOnONSlope : MonoBehaviour
    {
        public CharacterControl control;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                control.Slide = true;
            }
            else
            {
                return;
            }
        }
    }
}
