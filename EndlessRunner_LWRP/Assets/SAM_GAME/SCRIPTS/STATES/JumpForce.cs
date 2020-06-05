using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/JumpForce")]
    public class JumpForce : ScriptableObjectData
    {
        [SerializeField]
        private float jumpForce;

        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CameraManger.Instance.camController.TriggerCamera(CameraTrigger.Jump);
            playerStateBase.characterControl.RIGIDBODY.velocity = Vector3.zero;

            playerStateBase.characterControl.RIGIDBODY.AddForce
               (playerStateBase.characterControl.transform.up * jumpForce, ForceMode.Impulse);
         

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
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}