using UnityEngine;

namespace RunnerGame
{
    public class CameraState : StateMachineBehaviour
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            CameraTrigger[] arr = System.Enum.GetValues(typeof(CameraTrigger))
                as CameraTrigger[];

            foreach (CameraTrigger t in arr)
            {
                CameraManger.Instance.CAMERACONTROLLER.ANIMATOR.ResetTrigger(t.ToString());
            }
        }
    }
}