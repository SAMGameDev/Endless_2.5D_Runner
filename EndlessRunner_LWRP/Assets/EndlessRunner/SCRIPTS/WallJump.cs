using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/WallJump")]
    public class WallJump : ScriptableObjectData
    {     
        public float JumpForce2;
        public Vector3 RayPost;     
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = playerStateBase.GetCharacterControl(animator);
          //  Debug.DrawRay(control.transform.position + RayPost, control.transform.forward * 50f, Color.magenta);
            if (Physics.Raycast(control.transform.position + RayPost, control.transform.forward, out control.hitinfo, 0.5f))
            {
                if (!control.isGrounded && control.Jump == false
                 && control.hitinfo.collider.tag == "RightWall" || control.hitinfo.collider.tag == "LeftWall")
                {
                    control.WallSlideBool = true;
                }
                else
                {
                    control.WallSlideBool = false;
                }
            }
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }

}
