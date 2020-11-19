using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/ColliderTriggerController")]
    public class ColliderTriggerController : ScriptableObjectData
    {
        [SerializeField]
        [Range(0.01f, 1f)]
        private float turnOnTime;

        [SerializeField]
        [Range(0.01f, 1f)]
        private float turnOffTime;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            /*
             * This Code Controls Capsul Collider by making it trigger and  and non-trigger
             * it is appilied on some characters with special jump animation running (Running Jump)
             * on those character updatedBoxCollider Method is not working properly it is out of sync
             */
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= turnOnTime)
            {
                playerStateBase.characterControl.cCollider.isTrigger = true;
            }
            if (stateInfo.normalizedTime >= turnOffTime)
            {
                playerStateBase.characterControl.cCollider.isTrigger = false;
            }
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerStateBase.characterControl.cCollider.isTrigger = false;
        }
    }
}