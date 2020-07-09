using UnityEngine;

namespace EndlessRunning
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
