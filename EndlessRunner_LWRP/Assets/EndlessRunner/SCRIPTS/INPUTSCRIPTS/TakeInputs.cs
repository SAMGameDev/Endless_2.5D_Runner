using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class TakeInputs : MonoBehaviour
    {
        CharacterControl characterControl;
        void Start()
        {
            characterControl = GetComponent<CharacterControl>();
        }
        void Update()
        {
            if (Input.GetMouseButton(0) && Input.mousePosition.x <= Screen.width / 2
                || Input.GetKeyDown(KeyCode.Space))
            {
                characterControl.Dowalljump = true;
                characterControl.Jump = true;
            }
            else
            {
                characterControl.Dowalljump = false;
                characterControl.Jump = false;
            }

            if (Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width / 2
                || Input.GetKeyDown(KeyCode.RightArrow))
            {
                characterControl.Dash = true;
            }
            else
            {
                characterControl.Dash = false;
            }
        }
    }
}

