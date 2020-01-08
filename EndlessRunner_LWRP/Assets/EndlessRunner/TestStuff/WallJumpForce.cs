using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/WallJumpForce")]
    public class WallJumpForce : ScriptableObjectData
    {
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

            playerStateBase.characterControl.RIGIDBODY.velocity = Vector3.zero;
            playerStateBase.characterControl.RIGIDBODY.AddForce(-Vector3.forward * 28, ForceMode.VelocityChange);
            playerStateBase.characterControl.RIGIDBODY.AddForce(Vector3.up * 23, ForceMode.VelocityChange);
            playerStateBase.characterControl.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }

}
