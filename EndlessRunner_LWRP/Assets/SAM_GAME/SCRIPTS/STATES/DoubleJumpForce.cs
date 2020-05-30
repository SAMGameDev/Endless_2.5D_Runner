using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/DoubleJumpForce")]
    public class DoubleJumpForce : ScriptableObjectData
    {
        [SerializeField] private float DoubleJumpForce_Val;

        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            //playerStateBase.characterControl.RIGIDBODY.velocity = new Vector3
            //    (0f, DoubleJumpForce_Val, 0f);

            // playerStateBase.characterControl.FallMultiplier = 0;

            playerStateBase.characterControl.RIGIDBODY.AddRelativeForce(Vector3.up
                * DoubleJumpForce_Val);
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.DoubleJump], false);
           // playerStateBase.characterControl.FallMultiplier = 4f;
        }
    }
}