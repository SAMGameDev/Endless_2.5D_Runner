using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/Jump")]
    public class Jump : ScriptableObjectData
    {
        public float force_By_WallNormal;
        public float JumpForce;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            float normal_JumpForce = 25f;
            float Slope_JumpForce = 17;

            CharacterControl control = playerStateBase.GetCharacterControl(animator);

            if (!control.isOnSlope)
            {
                JumpForce = normal_JumpForce;
            }
            else
            {
                JumpForce = Slope_JumpForce;
            }

            if(control.makeWallJump)
            {
                control.RIGIDBODY.velocity = Vector3.zero;
                control.RIGIDBODY.AddForce(control.hitinfo.normal * force_By_WallNormal, ForceMode.VelocityChange);
                control.RIGIDBODY.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
                control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            control.RIGIDBODY.velocity = new Vector3(0, JumpForce, control.RIGIDBODY.velocity.z);
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
