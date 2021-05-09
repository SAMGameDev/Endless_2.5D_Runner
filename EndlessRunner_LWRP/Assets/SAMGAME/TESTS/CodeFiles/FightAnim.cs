using UnityEngine;

namespace EndlessRunning
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Fighting-System/FightAnim")]
    public class FightAnim : ScriptableObjectData
    {
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            playerStateBase.fightingSystem.OnFightHit += FightingSystem_OnFightHit; ;
        }

        private void FightingSystem_OnFightHit(object sender, MyEventaArgs e)
        {
            //e.anim.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Fight], true);
            Debug.Log("Fighting Area Detect switch to fight IDLE");
        }

        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}