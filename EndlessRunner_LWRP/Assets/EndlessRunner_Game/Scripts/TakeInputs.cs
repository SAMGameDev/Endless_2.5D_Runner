using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace RunnerGame
{
    public class TakeInputs : MonoBehaviour
    {
        public CharacterControl characterControl;
        void Start()
        {
            characterControl = GetComponent<CharacterControl>();
        }
        // Update is called once per frame
        void Update()
        {
            if (CrossPlatformInputManager.GetButtonDown("Jump") || Input.GetButtonDown("Jump"))
            {
                characterControl.Dowalljump = true;

                if (characterControl.IsGrounded)
                {
                    characterControl.Jump = true;
                    characterControl.CanDoubleJump = true;
                }
                if (!characterControl.IsGrounded && characterControl.CanDoubleJump == true)
                {
                    characterControl.CanDoubleJump = false;
                    characterControl.DoubleJump = true;
                }
            }
            else
            {
                characterControl.Dowalljump = false;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                characterControl.DoDash = true;
            }
        }
    }
}

