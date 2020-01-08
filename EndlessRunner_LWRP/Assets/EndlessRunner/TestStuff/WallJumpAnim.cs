using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/WallJumpAnim")]
    public class WallJumpAnim : ScriptableObjectData
    {
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (playerStateBase.characterControl.WallJump)
            {
                animator.SetBool(TranistionParemeters.WallJump.ToString(), true);
            }
            else
            {
                animator.SetBool(TranistionParemeters.WallJump.ToString(), false);
            }
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }

}
