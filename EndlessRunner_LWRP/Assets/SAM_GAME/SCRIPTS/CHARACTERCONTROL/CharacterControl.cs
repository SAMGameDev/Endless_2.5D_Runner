using UnityEngine;

namespace RunnerGame
{
    public enum TranistionParemeters
    {
        StartRun,
        Jump,
        ForceTransition,
        Grounded,
        Dash,
        Slide,
        DoubleJump,
        Die,
        OnClick,
    }
    public class CharacterControl : MonoBehaviour
    {
        [Header("CHARACTER-GENDER")]
        public CharacterGender gender;

        [Header("CharacterType")]
        public PlayableCharacterTypes Type;

        [Header("INPUTS")]
        public bool Jump;
        public bool Dash;
        public bool StartRun;
        public bool Slide;
        public bool isStarted = false;

        [Header("DETECTORS")]
        public bool isGrounded = true;
        public bool isDoubleJumping = false;
        public bool Death;

        [Header("FLOATS")]
        public float GravityMultipier;
        public float speed;

        [Header("UpdateBoxCollider")]
        public Vector3 targetCenter_C;
        public float targetHieght;
        public float CenterUpdate_Speed_C;
        public bool UpdateNow;

        [Header("SUB-COMPONENTS")]
        public Animator anim;

        public CapsuleCollider cCollider;
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
        private void Awake()
        {
            Death = false;
            StartRun = false;
            anim = GetComponentInChildren<Animator>();
            cCollider = GetComponent<CapsuleCollider>();
            RegisterCharacter();
        }

        public void RunForward(float speed)
        {
            RIGIDBODY.velocity = new Vector3(0f, RIGIDBODY.velocity.y, speed);
        }
        private void FixedUpdate()
        {
            ApplyGravity();
            UpdateCenter();
            UpdateSize();
        }
        private void ApplyGravity()
        {
            if (RIGIDBODY.velocity.y < 0)
            {
                RIGIDBODY.velocity += (Vector3.down * GravityMultipier);
            }
        }

        #region OnTrigger
        private void OnTriggerEnter(Collider other)
        {
            if (other.isTrigger && other.gameObject.CompareTag("Obsticel"))
            {
                Death = true;
            }
        }
        #endregion

        #region OnCollision
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Obsticel"))
            {
                Death = true;
            }
        }
        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("Ground")
                || other.gameObject.CompareTag("Slope"))
            {
                isGrounded = true;
            }
        }
        private void OnCollisionExit()
        {
            isGrounded = false;
        }
        #endregion
        private void UpdateCenter()
        {
            if (!UpdateNow)
            {
                return;
            }
            if (Vector3.SqrMagnitude(cCollider.center - targetCenter_C) > 0.01f)
            {
                cCollider.center = Vector3.Lerp(cCollider.center, targetCenter_C,
                    Time.deltaTime * CenterUpdate_Speed_C);
            }
        }
        private void UpdateSize()
        {
            if (!UpdateNow)
            {
                return;
            }
            else
            {
                cCollider.height = targetHieght;
            }
        }
        public void CacheCharacterControl(Animator animator)
        {
            PlayerStateBase[] arr = animator.GetBehaviours<PlayerStateBase>();

            foreach (PlayerStateBase c in arr)
            {
                c.characterControl = this;
            }
        }
        private void RegisterCharacter()
        {
            if (!CharacterManger.Instance.characters.Contains(this))
            {
                CharacterManger.Instance.characters.Add(this);
            }
        }
    }
}