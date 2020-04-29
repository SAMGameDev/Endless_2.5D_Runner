using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/SlideAnim")]
    public class SlideAnim : ScriptableObjectData
    {
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (playerStateBase.characterControl.Slide)
            {
                animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Slide], true);
            }
            else
            {
                animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Slide], false);
            }
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }
}
