using UnityEngine;
using System.Collections;

namespace RunnerGame
{
    public class TakeInputs : MonoBehaviour
    {
        private CharacterControl characterControl;
        void Awake()
        {
            characterControl = GetComponent<CharacterControl>();
        }
        void Update()
        {
            int splitScreen = Screen.height / 2;
            int spitscreenHori = Screen.width / 2;

            if (Input.GetMouseButtonDown(0)
               && Input.mousePosition.y >= splitScreen
               && Input.mousePosition.x <= spitscreenHori)
            {
                if (!characterControl.Start)
                {
                    characterControl.Start = true;
                }
                else
                {
                    characterControl.Jump = true;
                }
            }
            else if (Input.GetMouseButtonUp(0) && Input.mousePosition.y < splitScreen && Input.mousePosition.x <= spitscreenHori)
            {
                if (!characterControl.Start)
                {
                    characterControl.Start = true;
                }
                else
                {
                    characterControl.Slide = true;
                    StartCoroutine(TurnOff(0.3f));
                }
            }
            else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > spitscreenHori)
            {
                if (!characterControl.Start)
                {
                    characterControl.Start = true;
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

