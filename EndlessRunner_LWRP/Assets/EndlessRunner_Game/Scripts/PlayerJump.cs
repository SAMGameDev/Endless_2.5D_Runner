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

        public bool canWallJump_New;

        RaycastHit RightHitInfo;
        RaycastHit LeftHitinfo;

        public BoxCollider dectorCollider;
        public CharacterControl characterControl;
        void Start()
        {
            characterControl = GetComponent<CharacterControl>();
        }

        void FixedUpdate()
        {
            characterControl.IsGrounded = false;
            ApplyGravity();
            Jump();
            // WallJumping();
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
                characterControl.rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
            if (characterControl.DoubleJump == true)
            {
                characterControl.rb.AddForce(Vector3.up * DoubleJump_Force, ForceMode.Impulse);
                characterControl.CanDoubleJump = false;
            }
            characterControl.DoubleJump = false;
            characterControl.Jump = false;
        }

        /* void WallJumping()
         {
             if (Physics.Raycast(transform.position, transform.forward, out RightHitInfo, 0.5f))
             {

                 characterControl.CanwallJump = true;

                 if (!characterControl.IsGrounded && characterControl.Dowalljump == true && RightHitInfo.collider.tag == "RightWall")
                 {
                     characterControl.rb.velocity = Vector3.zero;
                     characterControl.rb.AddForce(RightHitInfo.normal * force_By_WallNormal, ForceMode.VelocityChange);
                     characterControl.rb.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
                     characterControl.CanwallJump = false;
                 }
                 else if (!characterControl.IsGrounded && characterControl.Dowalljump == false && RightHitInfo.collider.tag == "RightWall")
                 {
                     characterControl.rb.velocity = new Vector3(0, -wallSlide_Down, 0);
                 }
             }
             if (Physics.Raycast(transform.position, -transform.forward, out LeftHitinfo, 0.5f))
             {
                 characterControl.CanwallJump = true;

                 if (!characterControl.IsGrounded && characterControl.Dowalljump == true && LeftHitinfo.collider.tag == "LeftWall")
                 {
                     characterControl.rb.velocity = Vector3.zero;
                     characterControl.rb.AddForce(LeftHitinfo.normal * force_By_WallNormal, ForceMode.VelocityChange);
                     characterControl.rb.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
                     characterControl.CanwallJump = false;
                 }
                 else if (!characterControl.IsGrounded && characterControl.Dowalljump == false && LeftHitinfo.collider.tag == "LeftWall")
                 {
                     characterControl.rb.velocity = new Vector3(0, -wallSlide_Down, 0);
                 }
             }
         }*/
        void OnCollisionStay(Collision collision)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                if (!characterControl.IsGrounded && collision.collider.tag == "RightWall" || collision.collider.tag == "LeftWall")
                {
                    // Debug.DrawRay(contact.point, contact.normal, Color.yellow, 0.12f);   
                    characterControl.CanwallJump = true;

                    if (characterControl.Dowalljump == true)
                    {
                        characterControl.rb.velocity = Vector3.zero;
                        characterControl.rb.AddForce(contact.normal * force_By_WallNormal, ForceMode.VelocityChange);
                        characterControl.rb.AddForce(Vector3.up * 2.5f, ForceMode.VelocityChange);
                        characterControl.CanwallJump = false;
                    }
                    if (!characterControl.IsGrounded && collision.collider.tag == "RightWall")
                    {
                        
                        if (characterControl.Dowalljump == false)
                            Debug.Log("I Ran");
                        characterControl.rb.velocity = new Vector3(0, -wallSlide_Down, 0);
                    }
                }
                /* if (!characterControl.IsGrounded && collision.collider.tag == "RightWall")
                 {
                     Debug.Log("I Ran");
                     if (characterControl.CanwallJump == false)
                         characterControl.rb.velocity = new Vector3(0, -wallSlide_Down, 0);
                 }*/
            }
        }
        void OnTriggerStay(Collider other)
        {
            if (!other.isTrigger && other.gameObject.tag == "Ground")
            {
                characterControl.IsGrounded = true;
                characterControl.Dowalljump = false;
            }
        }
    }
}
