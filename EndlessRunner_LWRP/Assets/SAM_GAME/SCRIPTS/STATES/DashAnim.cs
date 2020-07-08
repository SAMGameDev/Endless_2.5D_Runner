using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/DashAnim")]
    public class DashAnim : ScriptableObjectData
    {
        public bool CanDash;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (playerStateBase.characterControl.isGrounded)
            {
                CanDash = true;

                if (playerStateBase.characterControl.Dash)
                {
                    animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Dash], true);
                }
            }
            else
            {
                if (CanDash && playerStateBase.characterControl.Dash)
                {
                    animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Dash], true);
                    CanDash = false;
                }
            }
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Dash], false);
        }
    }
}