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
        [SerializeField]
        protected float WallJump_UpwardForce;

        Vector3 lastPos;
        Vector3 currPos;

        RaycastHit leftHitInfo;
        RaycastHit RightHitInfo;

        public BoxCollider dectorCollider;
        public CharacterControl characterControl;
        void Start()
        {
            currPos = this.gameObject.transform.position;           
            characterControl = GetComponent<CharacterControl>();
        }

        void Update()
        {
            lastPos = this.gameObject.transform.position;
            Vector3 minusPos = currPos - lastPos;
            Debug.Log("lastpos" + minusPos);

            if(minusPos.z < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
          
        }
        void FixedUpdate()
        {
            characterControl.IsGrounded = false;
            ApplyGravity();
            Jump();
            WallJumping();
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
                characterControl.CanDoubleJUmp = false;
                characterControl.rb.AddForce(Vector3.up * DoubleJump_Force, ForceMode.Impulse);
            }
            characterControl.DoubleJump = false;
            characterControl.Jump = false;
        }
         void WallJumping()
         {
             if (Physics.Raycast(transform.position, transform.forward, out RightHitInfo, 0.5f))
             {
                 if (!characterControl.IsGrounded && RightHitInfo.collider.tag == "RightWall")
                 {
                     characterControl.CanDoubleJUmp = false;

                     if (characterControl.Dowalljump == true)
                     {
                         characterControl.rb.velocity = Vector3.zero;
                         characterControl.rb.AddForce(RightHitInfo.normal.normalized * force_By_WallNormal, ForceMode.VelocityChange);
                         characterControl.rb.AddForce(Vector3.up * WallJump_UpwardForce, ForceMode.VelocityChange);
                         characterControl.Dowalljump = false;
                     }
                     else if (!characterControl.IsGrounded && characterControl.Dowalljump == false && RightHitInfo.collider.tag == "RightWall")
                     {
                         characterControl.rb.velocity = new Vector3(0, -wallSlide_Down, 0);
                     }
                 }

             }
             if (Physics.Raycast(transform.position, -transform.forward, out leftHitInfo, 0.6f))
             {
                 if (!characterControl.IsGrounded && leftHitInfo.collider.tag == "LeftWall")
                 {
                     characterControl.CanDoubleJUmp = false;

                     if (characterControl.Dowalljump == true)
                     {
                         characterControl.rb.velocity = Vector3.zero;
                         characterControl.rb.AddForce(leftHitInfo.normal.normalized * force_By_WallNormal, ForceMode.VelocityChange);
                         characterControl.rb.AddForce(Vector3.up * WallJump_UpwardForce, ForceMode.VelocityChange);
                         characterControl.Dowalljump = false;
                     }
                     else if (!characterControl.IsGrounded && characterControl.Dowalljump == false && leftHitInfo.collider.tag == "LeftWall")
                     {
                         characterControl.rb.velocity = new Vector3(0, -wallSlide_Down, 0);
                     }
                 }

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
