using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/DeathForce")]
    public class DeathForce : ScriptableObjectData
    {
        [Range(0.01f, 1f)]
        public float animationProgres;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CameraManger.Instance.ShakeCamera(0.3f);
            playerStateBase.characterControl.Death = false;
            animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Die], false);

            if (playerStateBase.characterControl.RIGIDBODY.useGravity
                && stateInfo.normalizedTime >= animationProgres)
            {
                playerStateBase.characterControl.RIGIDBODY.useGravity = false;
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