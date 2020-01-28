using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/DoubleJumpAnim")]
    public class DoubleJumpAnim : ScriptableObjectData
    {
        public bool CanDoubleJump;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (playerStateBase.characterControl.isGrounded)
            {
                CanDoubleJump = true;
            }
            else
            {
                if (CanDoubleJump && playerStateBase.characterControl.Jump)
                {
                    animator.SetBool(TranistionParemeters.DoubleJump.ToString(), true);
                    CanDoubleJump = false;
                }
            }
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }

}
