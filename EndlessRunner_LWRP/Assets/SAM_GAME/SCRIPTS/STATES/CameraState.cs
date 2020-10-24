using UnityEngine;

namespace EndlessRunning
{
    public class CameraState : StateMachineBehaviour
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            CameraTriggers[] arr = System.Enum.GetValues(typeof(CameraTriggers))
                as CameraTriggers[];

            foreach (CameraTriggers t in arr)
            {
                CameraManger.Instance.CAMERACONTROLLER.animator.ResetTrigger(t.ToString());
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (stateInfo.normalizedTime >= 0.6f)
            {
                if (stateInfo.IsName("Shake"))
                {
                    CameraManger.Instance.
                        CAMERACONTROLLER.animator.SetTrigger(CameraTriggers.Default.ToString());
                }
            }
        }
    }
}