using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace RunnerGame
{
    public class TakeInputs : MonoBehaviour
    {
        private CharacterControl characterControl;
        void Start()
        {
            characterControl = GetComponent<CharacterControl>();
        }
        void Update()
        {
            if (CrossPlatformInputManager.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space))
            {
                characterControl.Dowalljump = true;
                characterControl.Jump = true;

            }
            else
            {
                characterControl.Dowalljump = false;
                characterControl.Jump = false;
            }
        }
    }
}

