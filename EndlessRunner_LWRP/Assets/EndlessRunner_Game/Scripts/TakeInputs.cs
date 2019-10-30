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
                   // characterControl.CanDoubleJump = true;
                    characterControl.Jump = true;
                }
               /* if (!characterControl.IsGrounded && characterControl.CanDoubleJump == true)
                {
                    characterControl.DoubleJump = true;
                    characterControl.CanDoubleJump = false;
                }  */             
            }
            else
            {
                characterControl.Dowalljump = false;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                characterControl.DoDash = true;
            }
            else
            {
                characterControl.DoDash = false;
            }
        }
    }
}

