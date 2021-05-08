﻿using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/ForceTransition")]
    public class ForceTransition : ScriptableObjectData
    {
        [SerializeField]
        [Range(0.01f, 1f)]
        protected float TransitionTiming;

        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= TransitionTiming)
            {
                animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.ForceTransition], true);
            }
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.ForceTransition], false);
        }
    }
}