using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/WallDetector")]
    public class WallDetector : ScriptableObjectData
    {
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = playerStateBase.GetCharacterControl(animator);

            if (control.CollidedWithWall)
            {
                control.RIGIDBODY.velocity = new Vector3(0, -0.01f, 0);
                animator.SetBool(TranistionParemeters.WallSlide.ToString(), true);
            }
            else
            {
                animator.SetBool(TranistionParemeters.WallSlide.ToString(), false);
            }

        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }

}
