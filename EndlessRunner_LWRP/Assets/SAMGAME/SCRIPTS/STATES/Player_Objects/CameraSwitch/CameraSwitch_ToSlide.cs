using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "new CameraSwitch_ToSlide", menuName = "ScriptableObject/CameraSystem/CameraSwitch_ToSlide")]
    public class CameraSwitch_ToSlide : ScriptableObjectData
    {
        [SerializeField]
        [Range(0.1f, 1f)]
        protected float Transitions;

        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CameraManger.Instance.Game_CamController.animator.SetTrigger(CameraTriggers.Slide.ToString());
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= Transitions)
            {
                CameraManger.Instance.Game_CamController.animator.SetTrigger(CameraTriggers.Default.ToString());
            }
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }
}