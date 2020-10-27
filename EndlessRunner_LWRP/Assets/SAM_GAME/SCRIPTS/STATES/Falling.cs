using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/Landing")]
    public class Falling : ScriptableObjectData
    {
        [Range(0.01f, 1f)]
        [SerializeField] protected float CamSwitch_transition;

        [SerializeField] protected AnimationCurve gravity;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerStateBase.characterControl.RIGIDBODY.velocity = Vector3.zero;
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerStateBase.characterControl.gravityMultiplier = gravity.Evaluate(stateInfo.normalizedTime);

            if (stateInfo.normalizedTime >= CamSwitch_transition)
            {
                CameraManger.Instance.CAMERACONTROLLER.animator.SetTrigger
                    (CameraTriggers.Default.ToString());
            }
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerStateBase.characterControl.gravityMultiplier = 0f;
        }
    }
}