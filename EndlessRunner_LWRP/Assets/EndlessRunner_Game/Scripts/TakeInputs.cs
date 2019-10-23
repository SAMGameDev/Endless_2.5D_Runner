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
                characterControl.Dowalljump = characterControl.CanwallJump;

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

