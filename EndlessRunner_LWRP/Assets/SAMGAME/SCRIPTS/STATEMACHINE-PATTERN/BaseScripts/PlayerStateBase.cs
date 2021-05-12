using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunning
{
    public class PlayerStateBase : StateMachineBehaviour
    {
        public List<ScriptableObjectData> scriptableObjectDatas = new List<ScriptableObjectData>();
        public CharacterControl characterControl;
        public FightingSystem fightingSystem;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (characterControl == null && fightingSystem == null)
            {
                CharacterControl control = animator.transform.root.GetComponent<CharacterControl>();
                FightingSystem Fsystem = animator.transform.root.GetComponent<FightingSystem>();
                control.CacheCharacterControl(animator);
                Fsystem.CacheFightingSystem(animator);
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