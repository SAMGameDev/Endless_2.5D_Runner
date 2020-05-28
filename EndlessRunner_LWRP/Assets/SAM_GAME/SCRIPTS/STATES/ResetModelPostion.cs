using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/ResetModelPostion")]
    public class ResetModelPostion : ScriptableObjectData
    {
        public Transform t;

        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            t = animator.GetComponent<Transform>();
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (t.position != playerStateBase.characterControl.transform.position)
            {
                t.position = playerStateBase.characterControl.transform.position;
            }
        }
    }
}