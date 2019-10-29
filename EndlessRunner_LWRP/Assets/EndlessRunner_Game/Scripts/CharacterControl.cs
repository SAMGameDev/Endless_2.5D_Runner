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
        public bool Dowalljump = false;
        public bool CanDoubleJump;
        public bool DoDash;


        public bool IsGrounded;
        public bool move;

        public float speed;
        public Rigidbody rb;

        //Dash Stuff. public vector3 moveDirection;
        public float DashSpeed;
        public float DashTime;
        public float DashStart_Time;

        void Start()
        {
            DashTime = DashStart_Time;
            rb = GetComponent<Rigidbody>();
        }
        void Update()
        {
            if (IsGrounded)
            {
                move = true;
            }
            else
            {
                move = false;
            }
        }
        void FixedUpdate()
        {
            if (move)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                rb.velocity = new Vector3(0, rb.velocity.y, speed);
            }         
        }
    }
}




