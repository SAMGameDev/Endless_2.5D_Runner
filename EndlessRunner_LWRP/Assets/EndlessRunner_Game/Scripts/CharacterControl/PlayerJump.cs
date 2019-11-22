using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField]
        protected float wallSlide_Down;
        [SerializeField]
        protected float force_By_WallNormal;
        public float JumpForce2;


        RaycastHit HitInfo;

        public Vector3 RayPost;

        private CharacterControl characterControl;
        void Start()
        {
            characterControl = GetComponent<CharacterControl>();
        }
        void Update()
        {
            // Jump();
           // WallJumping();
        }
       /* void FixedUpdate()
        {
            characterControl.IsGrounded = false;
        }
         public void Jump()
         {
             if (characterControl.Jump == true && characterControl.IsGrounded)
             {
                 characterControl.RIGIDBODY.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);

             }
         }
        void WallJumping()
        {
            //Debug.DrawRay(this.transform.position + RayPost, transform.forward * 500f, Color.white);
            if (Physics.Raycast(transform.position + RayPost, transform.forward, out HitInfo, 0.5f))
            {

                if (characterControl.Dowalljump && !characterControl.IsGrounded && HitInfo.collider.tag == "RightWall")
                {
                    characterControl.RIGIDBODY.velocity = Vector3.zero;
                    characterControl.RIGIDBODY.AddForce(HitInfo.normal * force_By_WallNormal, ForceMode.VelocityChange);
                    characterControl.RIGIDBODY.AddForce(Vector3.up * JumpForce2, ForceMode.VelocityChange);
                    this.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }
                if (!characterControl.IsGrounded && characterControl.Dowalljump == true && HitInfo.collider.tag == "LeftWall")
                {
                    characterControl.RIGIDBODY.velocity = Vector3.zero;
                    characterControl.RIGIDBODY.AddForce(HitInfo.normal * force_By_WallNormal, ForceMode.VelocityChange);
                    characterControl.RIGIDBODY.AddForce(Vector3.up * JumpForce2, ForceMode.VelocityChange);
                    this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
                else if (!characterControl.IsGrounded && characterControl.Dowalljump == false && HitInfo.collider.tag == "RightWall" || HitInfo.collider.tag == "LeftWall")
                {
                    characterControl.RIGIDBODY.velocity = new Vector3(0, -wallSlide_Down, 0);
                }
            }
        }*/
    }
}
