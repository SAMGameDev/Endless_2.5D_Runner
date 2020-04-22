using UnityEngine;

namespace RunnerGame
{
    public abstract class ScriptableObjectData : ScriptableObject
    {
        public abstract void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo);

    }
}

