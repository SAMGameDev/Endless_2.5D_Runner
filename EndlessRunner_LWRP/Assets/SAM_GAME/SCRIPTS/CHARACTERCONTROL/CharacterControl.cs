using UnityEngine;

namespace RunnerGame
{
    public enum TranistionParemeters
    {
        Start,
        Jump,
        ForceTransition,
        Grounded,
        Dash,
        Slide,
        DoubleJump,
    }
    public class CharacterControl : MonoBehaviour
    {
        [Header("INPUTS")]
        public bool Jump;
        public bool Dash;
        public bool Start;
        public bool DoubleJump;
        public bool Slide;

        [Header("DETECTORS")]
        public bool isGrounded = true;
        public bool isJumping;
        public bool Death;

        public float FallMultiplier = 9.8f;
        public int clickCount = 0;

        [Header("UpdateBoxCollider")]
        public Vector3 targetCenter_C;
        public Vector3 targetsize;
        public float CenterUpdate_Speed_C;
        public float sizeUpdate_Speed;
        public bool UpdateNow;

        [Header("SUB-COMPONENTS")]
        public Animator anim;
        public BoxCollider bCollider;
       [SerializeField] private Rigidbody rb;
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
            Death = false;
            Start = false;
            anim = GetComponentInChildren<Animator>();
            bCollider = GetComponent<BoxCollider>();
        }
        void FixedUpdate()
        {
            UpdateCenter();
            UpdateSize();
            ApplyGravity();
        }

        void UpdateCenter()
        {
            if (!UpdateNow)
            {
                return;
            }
            if (Vector3.SqrMagnitude(bCollider.center - targetCenter_C) > 0.01f)
            {
                bCollider.center = Vector3.Lerp(bCollider.center, targetCenter_C,
                    Time.deltaTime * CenterUpdate_Speed_C);
            }
        }
        void UpdateSize()
        {
            if (!UpdateNow)
            {
                return;
            }
            if (Vector3.SqrMagnitude(bCollider.size - targetsize) > 0.01f)
            {
                bCollider.size = Vector3.Lerp(bCollider.size, targetsize,
                    Time.deltaTime * sizeUpdate_Speed);
            }
        }
        void ApplyGravity()
        {
            float lowJumpGravity = 4.2f;
            float slopeFroce = 500;

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
            if (Slide)
            {
                RIGIDBODY.AddForce(Vector3.down * slopeFroce);
            }
        }
        void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Slope"))
            {
                isGrounded = true;
            }
            if (other.gameObject.CompareTag("Obsticel"))
            {
                Death = true;
            }
        }
        void OnCollisionExit(Collision collision)
        {
            isGrounded = false;
            Death = false;
        }

        public void RunForward(float speed)
        {
            RIGIDBODY.velocity = new Vector3(0f, RIGIDBODY.velocity.y, speed);
        }

        public void CacheCharacterControl(Animator animator)
        {
            PlayerStateBase[] arr = animator.GetBehaviours<PlayerStateBase>();

            foreach (PlayerStateBase c in arr)
            {
                c.characterControl = this;
            }
        }

    }
}