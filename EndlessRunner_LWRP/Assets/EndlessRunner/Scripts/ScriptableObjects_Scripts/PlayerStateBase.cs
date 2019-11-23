using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class PlayerStateBase : StateMachineBehaviour
    {
        public List<ScriptableObjectData> scriptableObjectDatas = new List<ScriptableObjectData>();

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (ScriptableObjectData d in scriptableObjectDatas)
            {
                d.OnEnter(this, animator, stateInfo);
            }
        }

        /*  public void UpdateAll(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
          {
              foreach (ScriptableObjectData d in scriptableObjectDatas)
              {
                  d.OnUpdate(playerStateBase, animator, stateInfo);
              }
          }*/

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // UpdateAll(this, animator, stateInfo);

            foreach (ScriptableObjectData d in scriptableObjectDatas)
            {
                d.OnUpdate(this, animator, stateInfo);
            }
        }
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (ScriptableObjectData d in scriptableObjectDatas)
            {
                d.OnExit(this, animator, stateInfo);
            }
        }

        private CharacterControl characterControl;
        public CharacterControl GetCharacterControl(Animator animator)
        {
            if (characterControl == null)
            {
                characterControl = animator.GetComponentInParent<CharacterControl>();
            }

            return characterControl;
        }
    }
}
