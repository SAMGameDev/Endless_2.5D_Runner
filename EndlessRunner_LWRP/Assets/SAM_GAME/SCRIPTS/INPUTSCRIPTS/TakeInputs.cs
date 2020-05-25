using UnityEngine;
using System.Collections;

namespace RunnerGame
{
    public class TakeInputs : MonoBehaviour
    {
        private CharacterControl characterControl;

        int splitScreenY = Screen.height / 2;
        int splitScreenX = Screen.width / 2;
        void Awake()
        {
            characterControl = GetComponent<CharacterControl>();
        }
        void Update()
        {
            if (characterControl.isStarted)
            {

                if (Input.GetMouseButtonDown(0)
                   && Input.mousePosition.y >= splitScreenY
                   && Input.mousePosition.x <= splitScreenX)
                {
                    if (!characterControl.StartRun)
                    {
                        characterControl.StartRun = true;
                    }
                    else
                    {
                        characterControl.Jump = true;
                    }
                }
                else if (Input.GetMouseButtonUp(0) && Input.mousePosition.y < splitScreenY && Input.mousePosition.x <= splitScreenX)
                {
                    if (!characterControl.StartRun)
                    {
                        characterControl.StartRun = true;
                    }
                    else
                    {
                        characterControl.Slide = true;
                        StartCoroutine(TurnOff(0.3f));
                    }
                }
                else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > splitScreenX || Input.GetKeyUp(KeyCode.RightShift))
                {
                    if (!characterControl.StartRun)
                    {
                        characterControl.StartRun = true;
                    }
                    else
                    {
                        characterControl.Dash = true;
                    }
                }
                else
                {
                    characterControl.Jump = false;
                    characterControl.Dash = false;
                }
            }
        }
        IEnumerator TurnOff(float time)
        {
            yield return new WaitForSeconds(time);

            if (characterControl.Slide)
            {
                characterControl.Slide = false;
            }
        }
    }
}

