using UnityEngine;

namespace RunnerGame
{
    public enum CameraTrigger
    {
        Default,
        Shake,
        Jump,
    }

    public class CameraController : MonoBehaviour
    {
        public Transform animTrans;

        private Animator animator;

        public Animator ANIMATOR
        {
            get
            {
                if (animator == null)
                {
                    animator = GetComponent<Animator>();
                }
                return animator;
            }
        }

        public void TriggerCamera(CameraTrigger trigger)
        {
            ANIMATOR.SetTrigger(trigger.ToString());
        }
    }
}