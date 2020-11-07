using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/DeathForce")]
    public class DeathForce : ScriptableObjectData
    {
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CameraManger.Instance.ShakeCamera(0.3f);
            playerStateBase.characterControl.RIGIDBODY.AddForce(-Vector3.forward * 1450, ForceMode.Force);
            playerStateBase.characterControl.GameOver = true;
            playerStateBase.characterControl.Death = false;
            animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Die], false);
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }
}