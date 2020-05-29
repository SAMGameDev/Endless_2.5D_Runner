using UnityEngine;

namespace RunnerGame
{
    public class CamFollowMovement : MonoBehaviour
    {
        public CharacterControl control;
      
        void Update()
        {
            transform.position = new Vector3(control.transform.position.x, 6.2f, control.transform.position.z);
        }
    }
}

