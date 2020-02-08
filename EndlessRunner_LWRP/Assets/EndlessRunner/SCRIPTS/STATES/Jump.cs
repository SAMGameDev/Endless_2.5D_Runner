using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/Jump")]
    public class Jump : ScriptableObjectData
    {
        [SerializeField]
        protected float JumpForce;
        [SerializeField]
        protected float forwardVel;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            float normal_JumpForce = 13;
            float Slope_JumpForce = 18;

            if (!playerStateBase.characterControl.isOnSlope)
            {
                JumpForce = normal_JumpForce;
            }
            else
            {
                JumpForce = Slope_JumpForce;
            }
           // playerStateBase.characterControl.RIGIDBODY.AddForce(Vector3.up * JumpForce, ForceMode.Force);
            playerStateBase.characterControl.RIGIDBODY.velocity = new Vector3
                (0f, JumpForce, forwardVel);
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerStateBase.characterControl.RIGIDBODY.velocity = Vector3.zero;
            JumpForce = 0f;
        }
    }

}
