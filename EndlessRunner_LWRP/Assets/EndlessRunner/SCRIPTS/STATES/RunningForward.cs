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

        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = playerStateBase.GetCharacterControl(animator);

            control.RIGIDBODY.velocity = new Vector3(0f, control.RIGIDBODY.velocity.y, speed);
            control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            if (control.Jump)
            {
                animator.SetBool(TranistionParemeters.Jump.ToString(), true);
            }
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }

}
