using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/Jump")]
    public class Jump : ScriptableObjectData
    {
        public float JumpForce;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
           playerStateBase.GetCharacterControl(animator).RIGIDBODY.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
            animator.SetBool(TranistionParemeters.Jump.ToString(), false);
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }

}
