using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
        Fight,
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

        [HideInInspector]
        public Vector3 targetCenter_C;
        [HideInInspector]
        public float SizeUpdate_Speed_C;
        [HideInInspector]
        public float targetHeight;
        [HideInInspector]
        public float CenterUpdate_Speed_C;

        [Header("UpdateBoxCollider")]
        public bool UpdateNow;

        [Header("Scripts")]
        public FightingSystem fightingSystem;

        [Header("SUB-COMPONENTS")]
        public TakeInputs input;
        public Animator anim;
        public CapsuleCollider cCollider;
        private Rigidbody rb;
        [Space(15)] public List<Collider> ragdollColliders = new List<Collider>();

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
            anim = GetComponentInChildren<Animator>();
            cCollider = GetComponent<CapsuleCollider>();
            input = GetComponent<TakeInputs>();
            SetRagdollParts();
            RegisterCharacter();
        }
       
        private void Update()
        {
            if (isStarted)
            {
                if (!StartRun)
                {
                    input.OnMousePressed_StartRun += Input_OnMousePressed_StartRun;
                }
                else
                {
                    input.OnMousePressed_Jump += Input_OnMousePressed_Jump;
                    Jump = false;
                    input.OnMousePressed_Dash += Input_OnMousePressed_Dash;
                    Dash = false;
                    input.OnMousePressed_Slide += Input_OnMousePressed_Slide;
                }
            }
        }

        private void FixedUpdate()
        {
            ApplyGravity();
            UpdateCenter();
            UpdateSize();
        }

        private void SetRagdollParts()
        {
            Collider[] colliders = gameObject.GetComponentsInChildren<Collider>();

            foreach (var item in colliders)
            {
                if (item.gameObject != gameObject)
                {
                    item.isTrigger = true;
                    ragdollColliders.Add(item);
                }
            }
        }

        public void RunForward(float speed)
        {
            RIGIDBODY.velocity = new Vector3(0f, RIGIDBODY.velocity.y, speed);
        }


        private void ApplyGravity()
        {
            if (RIGIDBODY.velocity.y < 0)
            {
                RIGIDBODY.velocity += (Vector3.down * gravityMultiplier);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                Death = true;
            }
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }

        private void OnCollisionExit()
        {
            isGrounded = false;
            Death = false;
        }

        private void UpdateCenter()
        {
            if (!UpdateNow)
            {
                return;
            }
            else if (Vector3.SqrMagnitude(cCollider.center - targetCenter_C) > 0.01f)
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
                cCollider.height = Mathf.Lerp(cCollider.height, targetHeight,
                    Time.deltaTime * SizeUpdate_Speed_C);
            }
        }

        public void CacheScripts(Animator animator)
        {
            PlayerStateBase[] arr = animator.GetBehaviours<PlayerStateBase>();

            foreach (PlayerStateBase p in arr)
            {
                p.characterControl = this;
                p.fightingSystem = fightingSystem;
            }
        }

        private void RegisterCharacter()
        {
            if (!CharacterManger.Instance.characters.Contains(this))
            {
                CharacterManger.Instance.characters.Add(this);
            }
        }
        #region Input Methods
        private void Input_OnMousePressed_StartRun(object sender, System.EventArgs e)
        {
            StartRun = true;
        }

        private void Input_OnMousePressed_Dash(object sender, System.EventArgs e)
        {
            Dash = true;
        }

        private void Input_OnMousePressed_Jump(object sender, System.EventArgs e)
        {
            Jump = true;
        }

        private void Input_OnMousePressed_Slide(object sender, System.EventArgs e)
        {
            Slide = true;
            StartCoroutine(TurnOff(0.25f));
        }

        private IEnumerator TurnOff(float time)
        {
            yield return new WaitForSeconds(time);

            if (Slide)
            {
                Slide = false;
            }
        }
        #endregion
        public void TurnOnRagdoll()
        {
            RIGIDBODY.useGravity = false;
            RIGIDBODY.velocity = Vector3.zero;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            anim.enabled = false;
            anim.avatar = null;

            foreach (var item in ragdollColliders)
            {
                item.isTrigger = false;
                item.attachedRigidbody.velocity = Vector3.zero;
            }
        }     
    }
}