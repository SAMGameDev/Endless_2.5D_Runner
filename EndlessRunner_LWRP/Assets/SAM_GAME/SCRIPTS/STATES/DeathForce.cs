using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/DeathForce")]
    public class DeathForce : ScriptableObjectData
    {
        [SerializeField]
        protected float backwardForce;

        [Range(0f, 1f)]
        public float timing;

        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerStateBase.characterControl.RIGIDBODY.AddForce
                (-playerStateBase.characterControl.transform.forward * backwardForce);
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= timing)
            {
                playerStateBase.characterControl.Death = false;
                playerStateBase.characterControl.cCollider.enabled = false;
                playerStateBase.characterControl.RIGIDBODY.useGravity = false;
                playerStateBase.characterControl.RIGIDBODY.velocity = Vector3.zero;
            }
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }
}