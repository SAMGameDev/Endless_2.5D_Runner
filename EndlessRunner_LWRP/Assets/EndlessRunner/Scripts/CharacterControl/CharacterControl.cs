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
        WallSlide,
        WallJump,
    }
    public class CharacterControl : MonoBehaviour
    {
        [Header("INPUTS")]
        public bool Jump;
        public bool Dash;

        [Header("DETECTORS")]
        public bool isGrounded;
        public bool isOnSlope;

        public bool Wallslide;
        public bool WallJump;
        public bool WallJump_L;

        [Header("Floats")]
        [SerializeField]
        protected float FallMultiplier;
        [SerializeField]
        protected float lowJumpGravity;
        [SerializeField]
        protected float slopeFroce;

        [Header("UpdateBoxCollider")]
        public Vector3 targetSize_C;
        public float SizeUpdate_Speed_C;
        public Vector3 targetCenter_C;
        public float CenterUpdate_Speed_C;
        public bool UpdateNow;

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
        void Awake()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 75;
            anim = GetComponentInChildren<Animator>();
            Bcollider = GetComponent<BoxCollider>();
        }
        public void CacheCharacterControl(Animator animator)
        {
            PlayerStateBase[] arr = animator.GetBehaviours<PlayerStateBase>();

            foreach (PlayerStateBase c in arr)
            {
                c.characterControl = this;
            }
        }
        void FixedUpdate()
        {
            UpdateCenter();
            UpdateSize();
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
            //fixing that bouncing effect On Slope
            if (isOnSlope)
            {
                RIGIDBODY.AddForce(Vector3.down * slopeFroce);
            }
        }
        void UpdateCenter()
        {
            if (!UpdateNow)
            {
                return;
            }
            if (Vector3.SqrMagnitude(Bcollider.center - targetCenter_C) > 0.01f)
            {
                Bcollider.center = Vector3.Lerp(Bcollider.center, targetCenter_C,
                    Time.fixedDeltaTime * CenterUpdate_Speed_C);
            }
        }
        void UpdateSize()
        {
            if (!UpdateNow)
            {
                return;
            }
            if (Vector3.SqrMagnitude(Bcollider.size - targetSize_C) > 0.01f)
            {
                Bcollider.size = Vector3.Lerp(Bcollider.size, targetSize_C,
                    Time.fixedDeltaTime * SizeUpdate_Speed_C);
            }
        }
        void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Slope"))
            {
                isGrounded = true;
            }
            if (collision.gameObject.CompareTag("Slope"))
            {
                isOnSlope = true;
            }
            if (!isGrounded && !Jump && collision.gameObject.CompareTag("RightWall")
                || collision.gameObject.CompareTag("LeftWall"))
            {
                Wallslide = true;
            }
            else
            {
                Wallslide = false;
            }
            if (!isGrounded && Jump && collision.gameObject.CompareTag("RightWall"))
            {
                WallJump = true;
            }
            else
            {
                WallJump = false;
            }
            if (!isGrounded && Jump && collision.gameObject.CompareTag("LeftWall"))
            {
                WallJump_L = true;
            }
            else
            {
                WallJump_L = false;
            }

        }
        void OnCollisionExit(Collision collision)
        {
            Wallslide = false;
            isGrounded = false;
            isOnSlope = false;
        }
    }
}




