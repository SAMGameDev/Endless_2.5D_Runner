using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/DashForce")]
    public class DashForce : ScriptableObjectData
    {
        [SerializeField]
        protected float dashForce;

        [SerializeField]
        protected float fallMultiplier;

        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CameraManger.Instance.ShakeCamera(0.2f);
            playerStateBase.characterControl.FallMultiplier = 0;
            playerStateBase.characterControl.RIGIDBODY.useGravity = false;
            playerStateBase.characterControl.RIGIDBODY.velocity = Vector3.zero;

            playerStateBase.characterControl.RIGIDBODY.AddForce
                (playerStateBase.characterControl.transform.forward * dashForce, ForceMode.Impulse);
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            //  playerStateBase.characterControl.RIGIDBODY.MovePosition
            //(playerStateBase.characterControl.transform.position +
            //playerStateBase.characterControl.transform.forward * dashForce * Time.deltaTime);
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerStateBase.characterControl.FallMultiplier = fallMultiplier;
            playerStateBase.characterControl.RIGIDBODY.useGravity = true;
            playerStateBase.characterControl.RIGIDBODY.velocity = Vector3.zero;
        }
    }
}