using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/UpdateBoxTest")]
    public class UpdateCollider : ScriptableObjectData
    {
        [SerializeField]
        protected Vector3 targetCenter;
        [SerializeField]
        protected float targetHieght;
        [SerializeField]
        protected float CenterUpdate_Speed;
        [SerializeField]
        public float sizeUpdate_Speed;

        [SerializeField]
        [Range(0.01f, 1f)]
        protected float Trans;

        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerStateBase.characterControl.UpdateNow = true;

            playerStateBase.characterControl.targetHeight = 0.85f;
            playerStateBase.characterControl.CenterUpdate_Speed_C = 600f;
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if(stateInfo.normalizedTime >= Trans)
            {
                playerStateBase.characterControl.UpdateNow = true;
                playerStateBase.characterControl.targetCenter_C = targetCenter;
                playerStateBase.characterControl.targetHeight = targetHieght;
                playerStateBase.characterControl.CenterUpdate_Speed_C = CenterUpdate_Speed;
                playerStateBase.characterControl.SizeUpdate_Speed_C = sizeUpdate_Speed;
            }
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerStateBase.characterControl.UpdateNow = false;
        }
    }
}