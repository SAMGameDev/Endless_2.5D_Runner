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
            if (playerStateBase.characterControl.WallJump)
            {
                playerStateBase.characterControl.RIGIDBODY.velocity = Vector3.zero;
                playerStateBase.characterControl.RIGIDBODY.AddForce(playerStateBase.characterControl.contacts_S.normal * 15f, ForceMode.VelocityChange);
                playerStateBase.characterControl.RIGIDBODY.AddForce(Vector3.up * 4f, ForceMode.VelocityChange);
                playerStateBase.characterControl.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            if (playerStateBase.characterControl.WallJump_L)
            {
                playerStateBase.characterControl.RIGIDBODY.velocity = Vector3.zero;
                playerStateBase.characterControl.RIGIDBODY.AddForce(playerStateBase.characterControl.contacts_S.normal * 15f, ForceMode.VelocityChange);
                playerStateBase.characterControl.RIGIDBODY.AddForce(Vector3.up * 4f, ForceMode.VelocityChange);
                playerStateBase.characterControl.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }

}
