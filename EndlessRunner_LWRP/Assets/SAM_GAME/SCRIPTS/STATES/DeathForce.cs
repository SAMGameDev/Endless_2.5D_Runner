using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/DeathForce")]
    public class DeathForce : ScriptableObjectData
    {
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerStateBase.characterControl.Death = false;
            animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Die], false);
            CameraManger.Instance.ShakeCamera(0.3f);
            
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