using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/DoubleJumpForce")]
    public class DoubleJumpForce : ScriptableObjectData
    {
        [SerializeField] protected float DoubleJumpForce_Val;

        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {         
            playerStateBase.characterControl.RIGIDBODY.velocity = Vector3.zero;

            playerStateBase.characterControl.RIGIDBODY.AddForce
                  (playerStateBase.characterControl.transform.up * DoubleJumpForce_Val, ForceMode.Impulse);
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.DoubleJump], false);
        }
    }
}