﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/DoubleJumpForce")]
    public class DoubleJumpForce : ScriptableObjectData
    {
        [SerializeField]
        protected bool CanDoubleJump;
        [SerializeField]
        protected float DoubleJumpForce_Val;
        [SerializeField]
        protected float forwardVel;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            //playerStateBase.characterControl.RIGIDBODY.velocity = new Vector3
            //  (0f, DoubleJumpForce_Val, forwardVel);
            playerStateBase.characterControl.RIGIDBODY.AddForce
                (Vector3.up * DoubleJumpForce_Val, ForceMode.Force);
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TranistionParemeters.DoubleJump.ToString(), false);
        }
    }
}
