using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/UpdateBoxCollider")]
    public class UpdateBoxCollider : ScriptableObjectData
    {
        [SerializeField]
        protected Vector3 targetCenter;
        [SerializeField]
        protected float CenterUpdate_Speed;
        [SerializeField]
        protected float targetHeight;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerStateBase.characterControl.UpdateNow = true;

            playerStateBase.characterControl.targetCenter_C = targetCenter;
            playerStateBase.characterControl.CenterUpdate_Speed_C = CenterUpdate_Speed;
            playerStateBase.characterControl.targetHeight = targetHeight;
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerStateBase.characterControl.UpdateNow = false;
        }
    }

}
