using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/VelocityRemover")]
    public class RemoveVelocity : ScriptableObjectData
    {
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerStateBase.characterControl.RIGIDBODY.velocity = Vector3.zero;
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }
}