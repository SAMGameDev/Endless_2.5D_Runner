using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/GroundDector")]
    public class GroundDector : ScriptableObjectData
    {
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (playerStateBase.characterControl.isGrounded)
            {
                animator.SetBool(TranistionParemeters.Grounded.ToString(), true);
            }
            else
            {
                animator.SetBool(TranistionParemeters.Grounded.ToString(), false);
            }

            if (playerStateBase.characterControl.isGrounded && !playerStateBase.characterControl.isOnSlope)
            {
                playerStateBase.characterControl.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
