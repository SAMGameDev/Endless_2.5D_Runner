using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/UpdateBoxCollider")]
    public class UpdateBoxCollider : ScriptableObjectData
    {
        public Vector3 targetCenter;
        public float CenterUpdate_Speed;
        public Vector3 targetSize;
        public float SizeUpdate_Speed;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerStateBase.characterControl.UpdateNow = true;

            playerStateBase.characterControl.targetCenter_C = targetCenter;
            playerStateBase.characterControl.CenterUpdate_Speed_C = CenterUpdate_Speed;
            playerStateBase.characterControl.targetSize_C = targetSize;
            playerStateBase.characterControl.SizeUpdate_Speed_C = SizeUpdate_Speed;

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
