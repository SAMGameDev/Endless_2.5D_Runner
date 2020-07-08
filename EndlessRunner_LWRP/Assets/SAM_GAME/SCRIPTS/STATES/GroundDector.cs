using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/GroundDector")]
    public class GroundDector : ScriptableObjectData
    {
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (playerStateBase.characterControl.isGrounded)
            {
                animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Grounded], true);
            }
            else
            {
                animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Grounded], false);
            }

            if (playerStateBase.characterControl.isGrounded && !playerStateBase.characterControl.Slide)
            {
                playerStateBase.characterControl.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }
}