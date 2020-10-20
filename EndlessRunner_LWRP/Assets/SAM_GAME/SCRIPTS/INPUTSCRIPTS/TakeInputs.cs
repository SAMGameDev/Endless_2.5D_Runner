using System.Collections;
using UnityEngine;

namespace EndlessRunning
{
    public class TakeInputs : MonoBehaviour
    {
        private CharacterControl characterControl;

        private int splitScreenY = Screen.height / 2;
        private int splitScreenX = Screen.width / 2;

        private void Awake()
        {
            characterControl = GetComponent<CharacterControl>();
        }

        private void Update()
        {
            if (characterControl.isStarted)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    if (!characterControl.StartRun)
                    {
                        characterControl.StartRun = true;
                    }

                    if (Input.mousePosition.y >= splitScreenY && Input.mousePosition.x <= splitScreenX)
                    {
                        characterControl.Jump = true;
                    }
                    else if (Input.mousePosition.y < splitScreenY && Input.mousePosition.x <= splitScreenX)
                    {
                        characterControl.Slide = true;
                        StartCoroutine(TurnOff(0.25f));
                    }
                    else if (Input.mousePosition.x > splitScreenX)
                    {
                        characterControl.Dash = true;
                    }
                }
                else
                {
                    characterControl.Jump = false;
                    characterControl.Dash = false;
                }
                #region old code
                //if (Input.GetMouseButtonUp(0)
                //   && Input.mousePosition.y >= splitScreenY
                //   && Input.mousePosition.x <= splitScreenX
                //   || Input.GetKeyDown(KeyCode.Space))
                //{
                //    if (!characterControl.StartRun)
                //    {
                //        characterControl.StartRun = true;
                //    }
                //    else
                //    {
                //        characterControl.Jump = true;
                //    }
                //}  
                //else if (Input.GetMouseButtonUp(0) &&
                //    Input.mousePosition.y < splitScreenY &&
                //    Input.mousePosition.x <= splitScreenX
                //    || Input.GetKeyDown(KeyCode.DownArrow))

                //{
                //    if (!characterControl.StartRun)
                //    {
                //        characterControl.StartRun = true;
                //    }
                //    else
                //    {
                //        characterControl.Slide = true;
                //        StartCoroutine(TurnOff(0.25f));
                //    }
                //}
                //else if (Input.GetMouseButtonUp(0)
                //    && Input.mousePosition.x > splitScreenX
                //    || Input.GetKeyDown(KeyCode.RightArrow))
                //{
                //    if (!characterControl.StartRun)
                //    {
                //        characterControl.StartRun = true;
                //    }
                //    else
                //    {
                //        characterControl.Dash = true;
                //    }
                //}
                #endregion
            }
        }
        private IEnumerator TurnOff(float time)
        {
            yield return new WaitForSeconds(time);

            if (characterControl.Slide)
            {
                characterControl.Slide = false;
            }
        }
    }
}