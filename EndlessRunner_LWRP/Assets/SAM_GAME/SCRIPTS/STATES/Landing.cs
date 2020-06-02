using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/Landing")]
    public class Landing : ScriptableObjectData
    {
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CameraManger.Instance.camController.TriggerCamera(CameraTrigger.Default);
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}