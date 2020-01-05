using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/WallDetector")]
    public class WallDetector : ScriptableObjectData
    {
        public Vector3 RayPost;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            //  Debug.DrawRay(control.transform.position + RayPost, control.transform.forward * 50f, Color.magenta);
            if (Physics.Raycast(playerStateBase.characterControl.transform.position + RayPost, playerStateBase.characterControl.transform.forward, out playerStateBase.characterControl.hitinfo, 0.5f))
            {
                if (!playerStateBase.characterControl.isGrounded && playerStateBase.characterControl.Jump == false
                 && playerStateBase.characterControl.hitinfo.collider.tag == "RightWall" || playerStateBase.characterControl.hitinfo.collider.tag == "LeftWall")
                {
                    playerStateBase.characterControl.WallSlideBool = true;
                }
                else
                {
                    playerStateBase.characterControl.WallSlideBool = false;
                }
            }
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }

}
