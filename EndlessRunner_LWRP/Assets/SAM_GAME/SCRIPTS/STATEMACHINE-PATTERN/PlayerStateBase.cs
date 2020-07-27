using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunning
{
    public class PlayerStateBase : StateMachineBehaviour
    {
        public List<ScriptableObjectData> scriptableObjectDatas = new List<ScriptableObjectData>();
        public CharacterControl characterControl;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // CHECKING IF characterControl IS NULL THEN GETTING CharacterControl FROM ANIMATOR
            //ROOT (TOP GAMEOBJECT) AND CALLING CacheCharacterControl METHON WHICH FILLS characterControl
            if (characterControl == null)
            {
                CharacterControl control = animator.transform.root.GetComponent<CharacterControl>();
                control.CacheCharacterControl(animator);              
            }

            foreach (ScriptableObjectData d in scriptableObjectDatas)
            {
                d.OnEnter(this, animator, stateInfo);
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
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
    }
}