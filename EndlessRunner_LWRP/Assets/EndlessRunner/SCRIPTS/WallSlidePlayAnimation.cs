using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/WallSlidePlayAnimation")]
    public class WallSlidePlayAnimation : ScriptableObjectData
    {
        public float force_By_WallNormal;
        public float JumpForce2;
        public Vector3 RayPost;
        RaycastHit HitInfo;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = playerStateBase.GetCharacterControl(animator);

            if(control.WallSlideBool)
            {
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
