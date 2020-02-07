using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class ForceWithKick : MonoBehaviour
    {
        [SerializeField]
        private CharacterControl control;
        private Rigidbody rb;
        BoxCollider bc;
        // Start is called before the first frame update
        void Start()
        {
            control = GameObject.FindObjectOfType<CharacterControl>();
            rb = GetComponent<Rigidbody>();
            bc = GetComponent<BoxCollider>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                rb.AddForce(Vector3.forward * 70, ForceMode.Force);
                rb.AddForce(Vector3.left * 40, ForceMode.Force);
                rb.AddForce(Vector3.up * 140, ForceMode.Force);
            }
        }
    }
}

