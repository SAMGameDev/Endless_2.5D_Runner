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

        public bool wallSlide;

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

            if (wallSlide == true)
            {
                characterControl.rb.velocity = new Vector3(0, -wallSlide_Down, 0);
            }
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
        void OnCollisionStay(Collision collision)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                if (!characterControl.IsGrounded && collision.collider.tag == "RightWall" || collision.collider.tag == "LeftWall")
                {
                    // Debug.DrawRay(contact.point, contact.normal, Color.yellow, 0.12f);   
                    characterControl.CanwallJump = true;

                    if (characterControl.Dowalljump)
                    {
                        characterControl.rb.velocity = Vector3.zero;
                        characterControl.rb.AddForce(contact.normal * force_By_WallNormal, ForceMode.VelocityChange);
                        characterControl.rb.AddForce(Vector3.up * 2.5f, ForceMode.VelocityChange);
                        characterControl.CanwallJump = false;
                    }
                    else
                    {
                        wallSlide = true;
                    }
                }
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            wallSlide = false;
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
