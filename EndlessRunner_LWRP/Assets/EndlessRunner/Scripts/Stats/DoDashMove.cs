using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/DoDashMove")]
    public class DoDashMove : ScriptableObjectData
    {
        public float DashForce;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = playerStateBase.GetCharacterControl(animator);

            Vector3 vel = control.RIGIDBODY.velocity;
            vel.z = 0f;
            control.RIGIDBODY.velocity = vel;

            control.RIGIDBODY.AddForce(Vector3.forward * DashForce, ForceMode.VelocityChange);
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }

}
