using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/RunForward")]
    public class RunningForward : ScriptableObjectData
    {
        [SerializeField]
        protected float speed;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TranistionParemeters.Dash.ToString(), false);
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerStateBase.characterControl.RIGIDBODY.velocity = new Vector3(0f, playerStateBase.characterControl.RIGIDBODY.velocity.y, speed);
            if (playerStateBase.characterControl.Dash)
            {
                animator.SetBool(TranistionParemeters.Dash.ToString(), true);
            }
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }

}
