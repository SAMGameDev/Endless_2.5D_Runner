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
           // float normal_JumpForce = 15;
           // float Slope_JumpForce = 15;

            CharacterControl control = playerStateBase.GetCharacterControl(animator);

          /*  if (!control.isOnSlope)
            {
                JumpForce = normal_JumpForce;
            }
            else
            {
                JumpForce = Slope_JumpForce;
            }*/
            control.RIGIDBODY.velocity = new Vector3(0, JumpForce, control.RIGIDBODY.velocity.z);

            Debug.Log(JumpForce);

        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
           // JumpForce = 0f;
        }
    }

}
