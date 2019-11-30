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
            float normalJumpForce = 13;
            float SlopeJumpForce = 22;

            CharacterControl control = playerStateBase.GetCharacterControl(animator);

            if (control.isOnSlope)
            {
                JumpForce = SlopeJumpForce;
            }
            else
            {
                JumpForce = normalJumpForce;
            }

            control.RIGIDBODY.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = playerStateBase.GetCharacterControl(animator);
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            JumpForce = 0f;
        }
    }

}
