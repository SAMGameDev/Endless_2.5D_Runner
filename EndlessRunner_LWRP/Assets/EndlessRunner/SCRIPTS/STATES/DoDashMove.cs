using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/DoDashMove")]
    public class DoDashMove : ScriptableObjectData
    {
        [SerializeField]
        protected float DashForce;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = playerStateBase.GetCharacterControl(animator);
            //control.RIGIDBODY.velocity = new Vector3(0f, control.RIGIDBODY.velocity.y, DashForce);
           // control.RIGIDBODY.AddForce(Vector3.forward * DashForce, ForceMode.Force);
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = playerStateBase.GetCharacterControl(animator);
            control.RIGIDBODY.AddForce(Vector3.forward * DashForce, ForceMode.Force);
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }

}
