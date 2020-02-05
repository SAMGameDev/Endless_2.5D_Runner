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
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            float normal_JumpForce = 13.7f;
            float Slope_JumpForce = 18;

            if (!playerStateBase.characterControl.isOnSlope)
            {
                JumpForce = normal_JumpForce;
            }
            else
            {
                JumpForce = Slope_JumpForce;
            }
            playerStateBase.characterControl.RIGIDBODY.velocity = new Vector3(0, JumpForce, 
                playerStateBase.characterControl.RIGIDBODY.velocity.z);
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
