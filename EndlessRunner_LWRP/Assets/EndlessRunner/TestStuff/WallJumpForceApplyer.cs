using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/WallJumpForceApplyer")]
    public class WallJumpForceApplyer : ScriptableObjectData
    {
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
         
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (playerStateBase.characterControl.Jump)
            {
                playerStateBase.characterControl.RIGIDBODY.AddForce(playerStateBase.characterControl.contacts_S.normal * 170
                  , ForceMode.VelocityChange);
                playerStateBase.characterControl.RIGIDBODY.AddForce(Vector3.up * 45
                    , ForceMode.VelocityChange);
            }       
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }

}
