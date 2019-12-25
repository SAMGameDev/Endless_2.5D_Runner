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
        [Header("INPUTS")]
        public bool Jump;
        public bool Dash;

        [Header("DETECTORS")]
        public bool isGrounded;
        public bool isOnSlope;

        [Header("Floats")]
        [SerializeField]
        protected float FallMultiplier;
        [SerializeField]
        protected float lowJumpGravity;
        [SerializeField]
        protected float slopeFroce;

        [Header("SUB-COMPONENTS")]
        public Animator anim;
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
        void Start()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
            anim = GetComponentInChildren<Animator>();
            Bcollider = GetComponent<BoxCollider>();
        }

        void Update()
        {
            //Time.timeScale = 0.25f;
        }

        void FixedUpdate()
        {
            ApplyGravity();
        }
        void ApplyGravity()
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
            //fixing that bouncing effect
            if (isOnSlope)
            {
                RIGIDBODY.AddForce(Vector3.down * slopeFroce);
            }

        }
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Slope"))
            {
                isGrounded = true;
            }
            if (collision.gameObject.CompareTag("Slope"))
            {
                isOnSlope = true;
            }
        }

        void OnCollisionExit(Collision collision)
        {
            //if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Slope"))
           // {
                isGrounded = false;
           // }
           // if (collision.gameObject.CompareTag("Slope"))
           // {
                isOnSlope = false;
           // }
        }
    }
}




