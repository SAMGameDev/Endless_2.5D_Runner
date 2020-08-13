using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunning
{
    public class RagDollTest : MonoBehaviour
    {
        [Header("RagdollParts")]
        public CharacterControl control;
        public List<Collider> ragDollColliders = new List<Collider>();
        public bool turnOn = false;
        void Awake()
        {
            SetupRagdollParts();
            control = GetComponent<CharacterControl>();
        }

        private void FixedUpdate()
        {
            if (control.Death)
            {
                TurnOnRagdoll();
            }
        }
        private void SetupRagdollParts()
        {
            Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();

            foreach (Collider c in colliders)
            {
                if (c.gameObject != this.gameObject)
                {
                    c.isTrigger = true;
                    ragDollColliders.Add(c);
                    c.attachedRigidbody.isKinematic = true;
                }
            }
        }

        private void TurnOnRagdoll()
        {
            control.RIGIDBODY.isKinematic = true;
            control.GravityMultipier = 0f;
            control.cCollider.enabled = false;
            control.anim.enabled = false;
            control.anim.avatar = null;

            foreach (Collider c in ragDollColliders)
            {
                if (c.isTrigger)
                {
                    c.isTrigger = false;
                    c.attachedRigidbody.isKinematic = false;
                    c.attachedRigidbody.velocity = Vector3.zero;
                }
            }
        }

        //private IEnumerator ragdollOn()
        //{
        //    yield return new WaitForSeconds(3f);
        //    control.RIGIDBODY.AddForce(Vector3.up * 700f);
        //    yield return new WaitForSeconds(0.6f);
        //    TurnOnRagdoll();
        //}
    }
}
