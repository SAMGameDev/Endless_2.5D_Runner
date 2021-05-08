using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "new CameraSwitch_ToDefault", menuName = "ScriptableObject/CameraSystem/CameraSwitch_ToDefault")]
    public class CameraSwitch_ToDefault : ScriptableObjectData
    {
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CameraManger.Instance.CAMERACONTROLLER.animator.SetTrigger(CameraTriggers.Default.ToString());
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (!CameraManger.Instance.CAMERACONTROLLER.animator.GetBool(CameraTriggers.Default.ToString()))
            {

            }
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            //CameraManger.Instance.CAMERACONTROLLER.animator.SetTrigger(CameraTriggers.Default.ToString());
        }
    }
}