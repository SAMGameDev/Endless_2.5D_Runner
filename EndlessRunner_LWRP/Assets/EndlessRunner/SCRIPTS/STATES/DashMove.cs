using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/DashMove")]
    public class DashMove : ScriptableObjectData
    {
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = playerStateBase.GetCharacterControl(animator);

            if (control.Dash)
            {
                animator.SetBool(TranistionParemeters.Dash.ToString(), true);

            }
            else
            {
                animator.SetBool(TranistionParemeters.Dash.ToString(), false);
            }
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
