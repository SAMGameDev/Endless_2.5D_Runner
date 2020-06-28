using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/DeathForce")]
    public class DeathForce : ScriptableObjectData
    {
        [SerializeField]
        protected float backwardForce;

        [SerializeField]
        [Range(0f, 1f)]
        protected float animationTime;

        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CameraManger.Instance.ShakeCamera(0.3f);

            playerStateBase.characterControl.RIGIDBODY.AddForce(Vector3.back * backwardForce, ForceMode.Impulse);

            playerStateBase.characterControl.RIGIDBODY.velocity = Vector3.zero;

            if (!playerStateBase.characterControl.RIGIDBODY.useGravity)
            {
                playerStateBase.characterControl.RIGIDBODY.useGravity = true;
            }
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }
}