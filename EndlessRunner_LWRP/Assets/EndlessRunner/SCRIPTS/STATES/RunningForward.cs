using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/RunForward")]
    public class RunningForward : ScriptableObjectData
    {
        public float speed;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TranistionParemeters.Dash.ToString(), false);
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
             CharacterControl control = playerStateBase.GetCharacterControl(animator);
             control.RIGIDBODY.velocity = new Vector3(0f, control.RIGIDBODY.velocity.y, speed);
            
            if (control.Jump)
            {
                animator.SetBool(TranistionParemeters.Jump.ToString(), true);
            }
            if (control.Dash)
            {
                animator.SetBool(TranistionParemeters.Dash.ToString(), true);
            }
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {         
        }
    }

}
