using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/SlideOnSlope")]
    public class SlideOnSlope : ScriptableObjectData
    {

        public float velocityOnY_DuringSlide;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = playerStateBase.GetCharacterControl(animator);
            if (control.isOnSlope)
            {
                control.RIGIDBODY.velocity = new Vector3(0, control.RIGIDBODY.velocity.y * velocityOnY_DuringSlide, 0);

            }
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }

}
