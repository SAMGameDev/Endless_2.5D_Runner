using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField]
        protected float JumpForce;
        [SerializeField]
        public float DoubleJump_Force;
        [SerializeField]
        protected float FallMultiplier;
        [SerializeField]
        protected float lowJumpGravity;
        [SerializeField]
        protected float wallSlide_Down;
        [SerializeField]
        protected float force_By_WallNormal;
      
        RaycastHit HitInfo;

        public Vector3 RayPost;

        public BoxCollider dectorCollider;
        public CharacterControl characterControl;
        void Start()
        {
            characterControl = GetComponent<CharacterControl>();
        }
        void Update()
        {
            Jump();
            WallJumping();

        }
        void FixedUpdate()
        {
            characterControl.IsGrounded = false;
            ApplyGravity();
        }
        public void ApplyGravity()
        {
            //if character is falling increase acceraltion
            if (characterControl.rb.velocity.y < 0f)
            {
                characterControl.rb.velocity += Vector3.up * Physics.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
            }
            //if it's  in air make him fall don't keep going up
            else if (characterControl.rb.velocity.y > 0f && characterControl.Jump == false)
            {
                characterControl.rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpGravity - 1) * Time.deltaTime;
            }
        }
        public void Jump()
        {
            if (characterControl.Jump == true)
            {
                //characterControl.rb.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
                characterControl.rb.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
            }
           /* if (characterControl.DoubleJump == true)
            {
                // characterControl.rb.AddForce(Vector3.up * DoubleJump_Force, ForceMode.VelocityChange);
                characterControl.rb.AddForce(Vector3.up * DoubleJump_Force, ForceMode.VelocityChange);
            }
            characterControl.DoubleJump = false;*/
            characterControl.Jump = false;
        }
        void WallJumping()
        {
            //Debug.DrawRay(this.transform.position + RayPost, transform.forward * 500f, Color.white);
            if (Physics.Raycast(transform.position + RayPost , transform.forward, out HitInfo, 0.5f))
            {              

                if (characterControl.Dowalljump && !characterControl.IsGrounded && HitInfo.collider.tag == "RightWall")
                {                   
                    characterControl.rb.velocity = Vector3.zero;
                    characterControl.rb.AddForce(HitInfo.normal * force_By_WallNormal, ForceMode.VelocityChange);
                    characterControl.rb.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
                    this.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }
                if (!characterControl.IsGrounded && characterControl.Dowalljump == true && HitInfo.collider.tag == "LeftWall")
                {
                    characterControl.rb.velocity = Vector3.zero;
                    characterControl.rb.AddForce(HitInfo.normal * force_By_WallNormal, ForceMode.VelocityChange);
                    characterControl.rb.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
                    this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
                else if (!characterControl.IsGrounded && characterControl.Dowalljump == false && HitInfo.collider.tag == "RightWall" || HitInfo.collider.tag == "LeftWall")
                {
                    characterControl.rb.velocity = new Vector3(0, -wallSlide_Down, 0);
                }
            }
        }
        void OnTriggerStay(Collider other)
        {
            if (!other.isTrigger && other.gameObject.tag == "Ground")
            {
                characterControl.IsGrounded = true;
            }
        }
    }
}
