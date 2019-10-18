using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class TakeInputs : MonoBehaviour
    {
        public CharacterControl characterControl;
        private void Start()
        {
           characterControl = GetComponent<CharacterControl>();
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (characterControl.IsGrounded)
                {
                    characterControl.Jump = true;
                    characterControl.CanDoubleJUmp = true;
                }
                if (!characterControl.IsGrounded)
                {
                    if (characterControl.CanDoubleJUmp)
                    {
                        characterControl.DoubleJump = true;
                    }
                    characterControl.Dowalljump = true;
                }
            }
            else
            {
                characterControl.Dowalljump = false;
            }
        }
    }
}

