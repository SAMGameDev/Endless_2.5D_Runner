using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "new CameraSwitch_OnFalling", menuName = "ScriptableObject/CameraSystem/CameraSwitch_OnFalling")]
    public class CameraSwitch_OnFalling : ScriptableObjectData
    {
        [SerializeField]
        [Range(0.01f, 1f)]
        private float camSwitch;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (!CameraManger.Instance.CAMERACONTROLLER.animator.GetBool(CameraTriggers.Default.ToString()))
            {
                if (stateInfo.normalizedTime >= camSwitch)
                {
                    CameraManger.Instance.CAMERACONTROLLER.animator.SetTrigger(CameraTriggers.Default.ToString());
                    Debug.LogWarning("Called camswitch");
                }
            }
            else
            {
                return;
            }
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }
}