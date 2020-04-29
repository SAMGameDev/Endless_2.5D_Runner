using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/JumpAnim")]
    public class JumpAnim : ScriptableObjectData
    {
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
           // animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Dash], false);
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (playerStateBase.characterControl.Jump &&
                playerStateBase.characterControl.isGrounded == true)
            {
                animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Jump], true);
            }
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Jump], false);
        }
    }
}
