using UnityEngine;

namespace RunnerGame
{
    public class SelectCameraState : StateMachineBehaviour
    {
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            PlayableCharacterTypes[] arr = System.Enum.GetValues
                (typeof(PlayableCharacterTypes)) as PlayableCharacterTypes[];

            foreach (PlayableCharacterTypes p in arr)
            {
                animator.SetBool(p.ToString(), false);
            }
        }
    }
}