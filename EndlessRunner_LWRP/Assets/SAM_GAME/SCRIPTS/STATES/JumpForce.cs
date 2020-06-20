using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/JumpForce")]
    public class JumpForce : ScriptableObjectData
    {
        [SerializeField]
        protected float jumpForce;

        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CameraManger.Instance.CAMERACONTROLLER.ANIMATOR.SetTrigger(CameraTriggers.Jump.ToString());
            playerStateBase.characterControl.RIGIDBODY.velocity = Vector3.zero;

            playerStateBase.characterControl.RIGIDBODY.AddForce
               (playerStateBase.characterControl.transform.up * jumpForce, ForceMode.Impulse);
            #region slope jump
            //float Slope_JumpForce = 1000;

            //if (!playerStateBase.characterControl.Slide)
            //{
            //    jumpForce ;
            //}
            //else
            //{
            //    jumpForce = Slope_JumpForce;
            //}
            // playerStateBase.characterControl.RIGIDBODY.velocity = new Vector3
            //  (0f, JumpForce, forwardVel);
            #endregion
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            //CameraManger.Instance.CAMERACONTROLLER.ANIMATOR.SetTrigger(CameraTrigger.Default.ToString());
        }
    }
}