using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/Slide")]
    public class Slide : ScriptableObjectData
    {
        [SerializeField]
        [Range(0.1f, 1f)]
        protected float Transitions;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CameraManger.Instance.camController.ANIMATOR.SetTrigger(CameraTriggers.Slide.ToString());
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= Transitions)
            {
                CameraManger.Instance.camController.ANIMATOR.SetTrigger(CameraTriggers.Default.ToString());
            }
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }
}