using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public enum TranistionParemeters
    {
        Jump,
        ForceTransition,
        Grounded,
        Run,
        Dash,
        OnSlope,
    }
    public class CharacterControl : MonoBehaviour
    {
        //inputs
        public bool Jump;
        public bool Dowalljump = false;
        public bool Dash;

        public bool isGrounded;
        public bool isOnSlope;

        [SerializeField]
        protected float FallMultiplier;
        [SerializeField]
        protected float lowJumpGravity;
        [SerializeField]
        protected float FallMultiplieragain;

        public Animator animator;
        public BoxCollider Bcollider;


        private Rigidbody rb;
        public Rigidbody RIGIDBODY
        {
            get
            {
                if (rb == null)
                {
                    rb = GetComponent<Rigidbody>();
                }
                return rb;
            }
        }
        void FixedUpdate()
        {
            ApplyGravity();
        }
        public void ApplyGravity()
        {
            //if character is falling increase acceraltion
            if (RIGIDBODY.velocity.y < 0f)
            {
                RIGIDBODY.velocity += Vector3.up * Physics.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
            }
            //if it's  in air make him fall don't keep going up
            else if (RIGIDBODY.velocity.y > 0f && Jump == false)
            {
                RIGIDBODY.velocity += Vector3.up * Physics.gravity.y * (lowJumpGravity - 1) * Time.deltaTime;
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
            if (collision.contacts[0].normal != Vector3.up)
            {               
                Debug.Log("IT is a fucking slope");
                isOnSlope = true;
            }
            else
            {
                isOnSlope = false;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = false;
            }
        }
    }
}




