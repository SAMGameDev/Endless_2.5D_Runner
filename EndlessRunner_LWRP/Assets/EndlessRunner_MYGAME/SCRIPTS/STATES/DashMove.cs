using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/DoDashMove")]
    public class DashMove : ScriptableObjectData
    {
        [SerializeField]
        protected float DashForce;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            //playerStateBase.characterControl.RIGIDBODY.AddForce
                // (playerStateBase.characterControl.transform.forward * DashForce, ForceMode.Force);
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TranistionParemeters.Dash.ToString(), false);
        }
    }

}
