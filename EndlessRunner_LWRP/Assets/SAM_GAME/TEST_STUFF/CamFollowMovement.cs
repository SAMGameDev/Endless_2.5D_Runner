using UnityEngine;

namespace RunnerGame
{
    public class CamFollowMovement : MonoBehaviour
    {
        public CharacterControl control;
        public Vector3 offset;

        private void Awake()
        {
            control = GetComponentInParent<CharacterControl>();
        }

        private void Update()
        {
            //Vector3 pos = new Vector3(control.transform.position.x,
            //  control.transform.position.y, control.transform.position.z) + offset;

            if (control.transform.position.y < 0 && control.isGrounded)
            {
                transform.position = new Vector3(control.transform.position.x,
              control.transform.position.y, control.transform.position.z) + offset;
            }
            else
            {
                transform.position = new Vector3(control.transform.position.x,
               0f, control.transform.position.z) + offset;
            }
        }
    }
}