using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

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
                    characterControl.CanDoubleJump = true;
                }
                if (!characterControl.IsGrounded && characterControl.CanDoubleJump == true)
                {
                    characterControl.DoubleJump = true;
                }
            }

            if (Input.GetButtonDown("Jump"))
            {
                characterControl.Dowalljump = true;
            }
            else
            {
                characterControl.Dowalljump = false;
            }
        }
    }
}

