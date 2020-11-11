using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/DoubleJump")]
    public class DoubleJump : ScriptableObjectData
    {
        [SerializeField] private bool CanDoubleJump = true;

        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (playerStateBase.characterControl.isGrounded)
            {
                CanDoubleJump = true;
            }
            else
            {
                if (CanDoubleJump && playerStateBase.characterControl.Jump)
                {
                    animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.DoubleJump], true);
                    CanDoubleJump = false;
                }
                else
                {
                    animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.DoubleJump], false);
                }
            }
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }
}