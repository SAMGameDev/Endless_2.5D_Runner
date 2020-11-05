using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/JumpCollider")]
    public class JumpCollider : ScriptableObjectData
    {
        [SerializeField]
        [Range(0.01f,1f)]
        public float transTime;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerStateBase.characterControl.cCollider.isTrigger = true;
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if(stateInfo.normalizedTime >= transTime)
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