﻿using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/Landing")]
    public class Landing : ScriptableObjectData
    {
        [Range(0.1f, 1f)]
        [SerializeField] protected float transition;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= transition)
            {
                CameraManger.Instance.CAMERACONTROLLER.ANIMATOR.SetTrigger(CameraTriggers.Default.ToString());
            }
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}