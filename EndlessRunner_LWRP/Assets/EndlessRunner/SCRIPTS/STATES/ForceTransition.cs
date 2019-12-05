using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/ForceTransition")]
    public class ForceTransition : ScriptableObjectData
    {
        [Range(0.01f, 1f)]
        public float TransitionTiming;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = playerStateBase.GetCharacterControl(animator);

            if(stateInfo.normalizedTime >= TransitionTiming)
            {
                animator.SetBool(TranistionParemeters.ForceTransition.ToString(), true);
            }
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TranistionParemeters.ForceTransition.ToString(), false);
        }
    }

}
