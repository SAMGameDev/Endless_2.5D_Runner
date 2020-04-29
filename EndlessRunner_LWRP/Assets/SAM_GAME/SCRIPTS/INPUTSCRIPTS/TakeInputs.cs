using UnityEngine;

namespace RunnerGame
{
    public class TakeInputs : MonoBehaviour
    {
        CharacterControl characterControl;
        void Awake()
        {
            characterControl = GetComponent<CharacterControl>();
        }
        void Update()
        {
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.x <= Screen.width / 2
                || Input.GetKeyDown(KeyCode.Space))
            {
                characterControl.Jump = true;

                if (!characterControl.Start)
                {
                    characterControl.Start = true;
                }
            }
       else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width / 2
                || Input.GetKeyDown(KeyCode.RightArrow))
            {
                characterControl.Dash = true;
                if (!characterControl.Start)
                {
                    characterControl.Start = true;
                }
            }
            else
            {
                characterControl.Jump = false;
                characterControl.Dash = false;
            }
        }
    }
}

