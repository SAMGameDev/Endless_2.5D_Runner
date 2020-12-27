using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "new CameraSwitch_ToDefault", menuName = "ScriptableObject/CameraSystem/CameraSwitch_ToDefault")]
    public class CameraSwitch_ToDefault : ScriptableObjectData
    {
        [Range(0.01f, 1f)]
        [SerializeField] protected float CamSwitch_transition;

        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CameraManger.Instance.Game_CamController.animator.SetTrigger(CameraTriggers.Slide.ToString());
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= CamSwitch_transition)
            {
                CameraManger.Instance.CAMERACONTROLLER.animator.SetTrigger
                    (CameraTriggers.Default.ToString());
            }
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }
}