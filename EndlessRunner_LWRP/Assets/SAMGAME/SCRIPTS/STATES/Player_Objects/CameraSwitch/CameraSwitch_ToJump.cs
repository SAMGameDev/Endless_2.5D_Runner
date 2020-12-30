using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "new CameraSwitch_ToJump", menuName = "ScriptableObject/CameraSystem/CameraSwitch_ToJump")]
    public class CameraSwitch_ToJump : ScriptableObjectData
    {
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CameraManger.Instance.CAMERACONTROLLER.animator.SetTrigger(CameraTriggers.Jump.ToString());
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            //CameraManger.Instance.CAMERACONTROLLER.animator.SetTrigger(CameraTriggers.Default.ToString());
        }
    }
}