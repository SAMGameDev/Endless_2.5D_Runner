using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class CharacterControl : MonoBehaviour
    {
        //inputs
        public bool Jump;
        public bool DoubleJump;
        public bool Dowalljump;
        public bool CanDoubleJUmp;

        public bool IsGrounded;

        public float speed;
        public Rigidbody rb;

        private void Start()
        {
            Application.targetFrameRate = 60;
            rb = GetComponent<Rigidbody>();
        }
        void Update()
        {

            if (IsGrounded)
            {
                rb.velocity = new Vector3(0, rb.velocity.y, speed);
            }
        }

        void FixedUpdate()
        {      
        }
    }
}




