using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/StartRunning")]
    public class StartRunning : ScriptableObjectData
    {
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (playerStateBase.characterControl.StartRun)
            {
                animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.StartRun],true);
            }
            else
            {
                animator.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.StartRun],false);
            }
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CameraManger.Instance.CAMERACONTROLLER.TriggerCamera(CameraTriggers.Default);
        }
    }
}