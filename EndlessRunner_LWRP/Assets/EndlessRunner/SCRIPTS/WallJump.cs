using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/WallJump")]
    public class WallJump : ScriptableObjectData
    {

        [SerializeField]
        protected float wallSlide_Down;
        [SerializeField]
        protected float force_By_WallNormal;
        public float JumpForce2;

        RaycastHit HitInfo;

        public Vector3 RayPost;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

            Debug.DrawRay(playerStateBase.characterControl.transform.position + RayPost, playerStateBase.characterControl.transform.forward * 50f, Color.white);
            if (Physics.Raycast(playerStateBase.characterControl.transform.position + RayPost, playerStateBase.characterControl.transform.forward, out HitInfo, 0.5f))
            {

                if (playerStateBase.characterControl.Jump && !playerStateBase.characterControl.isGrounded
                    && HitInfo.collider.tag == "RightWall")
                {
                    playerStateBase.characterControl.RIGIDBODY.velocity = Vector3.zero;
                    playerStateBase.characterControl.RIGIDBODY.AddForce(HitInfo.normal * force_By_WallNormal, ForceMode.VelocityChange);
                    playerStateBase.characterControl.RIGIDBODY.AddForce(Vector3.up * JumpForce2, ForceMode.VelocityChange);
                    playerStateBase.characterControl.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }
                if (!playerStateBase.characterControl.isGrounded && playerStateBase.characterControl.Jump == true
                    && HitInfo.collider.tag == "LeftWall")
                {
                    playerStateBase.characterControl.RIGIDBODY.velocity = Vector3.zero;
                    playerStateBase.characterControl.RIGIDBODY.AddForce(HitInfo.normal * force_By_WallNormal, ForceMode.VelocityChange);
                    playerStateBase.characterControl.RIGIDBODY.AddForce(Vector3.up * JumpForce2, ForceMode.VelocityChange);
                    playerStateBase.characterControl.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
                else if (!playerStateBase.characterControl.isGrounded && playerStateBase.characterControl.Jump == false
                    && HitInfo.collider.tag == "RightWall" || HitInfo.collider.tag == "LeftWall")
                {
                    animator.SetBool(TranistionParemeters.WallSlide.ToString(), true);
                    playerStateBase.characterControl.RIGIDBODY.velocity = new Vector3(0, -wallSlide_Down, 0);
                }
            }
        }

        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

    }

}
