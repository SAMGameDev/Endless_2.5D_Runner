using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/Jump")]
    public class Jump : ScriptableObjectData
    {
        [SerializeField]
        private float JumpForce;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            float normal_JumpForce = 780;
            float Slope_JumpForce = 1000;

            if (!playerStateBase.characterControl.isOnSlope)
            {
                JumpForce = normal_JumpForce;
            }
            else
            {
                JumpForce = Slope_JumpForce;
            }
            // playerStateBase.characterControl.RIGIDBODY.velocity = new Vector3
            //  (0f, JumpForce, forwardVel);
            playerStateBase.characterControl.RIGIDBODY.AddForce
                (playerStateBase.characterControl.transform.up * JumpForce);
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            JumpForce = 0f;
        }
    }

}
