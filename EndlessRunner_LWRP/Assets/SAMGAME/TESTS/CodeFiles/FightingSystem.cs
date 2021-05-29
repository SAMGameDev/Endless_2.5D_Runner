using UnityEngine;

namespace EndlessRunning
{
    public class FightingSystem : MonoBehaviour
    {
        public bool FightMod;

        private void Awake()
        {
            FightMod = false;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "FightTrigger")
            {
                FightMod = true;
            }
            //must flase the FightMod Bool in order to switch back to run mode
        }
    }
}

