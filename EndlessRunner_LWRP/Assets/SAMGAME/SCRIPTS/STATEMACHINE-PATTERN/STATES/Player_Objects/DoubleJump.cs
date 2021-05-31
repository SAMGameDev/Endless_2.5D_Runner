using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/DoubleJump")]
    public class DoubleJump : ScriptableObjectData
    {
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        } 
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            bool CanDoubleJump = true;

            if (playerStateBase.characterControl.isGrounded)
            {
                CanDoubleJump = true;
            }
            else
            {
                if (CanDoubleJump && playerStateBase.characterControl.Jump)
                {
                    animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.DoubleJump], true);
                    CanDoubleJump = false;
                }
            }
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }
}