using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/DashForce")]
    public class DashForce : ScriptableObjectData
    {
        [SerializeField]
        protected float dashForce;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerStateBase.characterControl.FallMultiplier = 0;
            playerStateBase.characterControl.RIGIDBODY.velocity = Vector3.zero;
            CameraManger.Instance.ShakeCamera(0.03f);
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerStateBase.characterControl.RIGIDBODY.MovePosition
               (playerStateBase.characterControl.transform.position +
               playerStateBase.characterControl.transform.forward * dashForce * Time.deltaTime);
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerStateBase.characterControl.FallMultiplier = 9.8f;
        }

    }

}
