using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class WallJumpTest : MonoBehaviour
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
             WallJumping();
        }
        void FixedUpdate()
        {

        }

        void WallJumping()
        {
            Debug.DrawRay(this.transform.position + RayPost, transform.forward * 50f, Color.white);
            if (Physics.Raycast(transform.position + RayPost, transform.forward, out HitInfo, 0.5f))
            {

                if (characterControl.Dowalljump && !characterControl.isGrounded
                    && HitInfo.collider.tag == "RightWall")
                {
                    characterControl.RIGIDBODY.velocity = Vector3.zero;
                    characterControl.RIGIDBODY.AddForce(HitInfo.normal * force_By_WallNormal, ForceMode.VelocityChange);
                    characterControl.RIGIDBODY.AddForce(Vector3.up * JumpForce2, ForceMode.VelocityChange);
                    this.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }
                if (!characterControl.isGrounded && characterControl.Dowalljump == true
                    && HitInfo.collider.tag == "LeftWall")
                {
                    characterControl.RIGIDBODY.velocity = Vector3.zero;
                    characterControl.RIGIDBODY.AddForce(HitInfo.normal * force_By_WallNormal, ForceMode.VelocityChange);
                    characterControl.RIGIDBODY.AddForce(Vector3.up * JumpForce2, ForceMode.VelocityChange);
                    this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
                else if (!characterControl.isGrounded && characterControl.Dowalljump == false
                    && HitInfo.collider.tag == "RightWall" || HitInfo.collider.tag == "LeftWall")
                {
                    characterControl.RIGIDBODY.velocity = new Vector3(0, -wallSlide_Down, 0);
                }
            }
        }
    }
}
