using UnityEngine;

namespace EndlessRunning
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
        public PlayableCharacterTypes TYPE;

        [Header("INPUTS")]
        public bool Jump;

        public bool Dash;
        public bool StartRun;
        public bool Slide;

        [Header("ExtraBool")]
        public bool isStarted = false;

        [Header("DETECTORS")]
        public bool isGrounded = true;

        public bool Death;
        public bool GameOver = false;

        [Header("FLOATS")]
        public float gravityMultiplier;

        public float speed;

        [Header("UpdateBoxCollider")]
        public Vector3 targetCenter_C;

        public float targetHeight;
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

        #region Unity Default Methods

        private void Awake()
        {
            Death = false;
            StartRun = false;
            anim = GetComponentInChildren<Animator>();
            cCollider = GetComponent<CapsuleCollider>();
            RegisterCharacter();
        }

        private void FixedUpdate()
        {
            ApplyGravity();
            UpdateCenter();
            UpdateSize();
        }

        #endregion Unity Default Methods

        #region RunForward

        public void RunForward(float speed)
        {
            RIGIDBODY.velocity = new Vector3(0f, RIGIDBODY.velocity.y, speed);
        }

        #endregion RunForward

        #region Gravity Apply

        private void ApplyGravity()
        {
            if (RIGIDBODY.velocity.y < 0)
            {
                RIGIDBODY.velocity += (Vector3.down * gravityMultiplier);
            }
        }

        #endregion Gravity Apply

        #region OnTrigger

        // Death With On Trigger when there's no surface Under Player
        private void OnTriggerEnter(Collider other)
        {
            if (other.isTrigger && other.gameObject.CompareTag("Obstacle"))
            {
                Death = true;
            }
        }

        #endregion OnTrigger

        #region OnCollision

        // DEATH WHEN PLAYER COLLIDE WITH ANY OBSTECLE
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
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
            Death = false;
        }

        #endregion OnCollision

        #region Update Collider on Runtime

        //UPDATE COLLIDERS (SIZE AND CENTER) WHEN PLAYER JUMPS, FALLS, SLIDE ETC
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
                cCollider.height = targetHeight;
            }
        }

        #endregion Update Collider on Runtime

        #region Caching CharacterControl in playerStateBase

        // THIS FUNCTION GETTING ALL PLAYERSTATEBASE AND FILLING CHARACTERCONTROL VARIABLE
        // IN ALL PLAYERSTATEBASE WITH THIS SCRIPT (CHARACTERcONTROL)
        public void CacheCharacterControl(Animator animator)
        {
            PlayerStateBase[] arr = animator.GetBehaviours<PlayerStateBase>();

            foreach (PlayerStateBase p in arr)
            {
                p.characterControl = this;
            }
        }

        #endregion Caching CharacterControl in playerStateBase

        #region Register CharacterControl In Manger

        private void RegisterCharacter()
        {
            if (!CharacterManger.Instance.characters.Contains(this))
            {
                CharacterManger.Instance.characters.Add(this);
            }
        }

        #endregion Register CharacterControl In Manger
    }
}