using System.Collections;
using UnityEngine;
using System;

namespace EndlessRunning
{
    public class TakeInputs : MonoBehaviour
    {
        private CharacterControl characterControl;

        public event EventHandler OnMousePressed_StartRun;
        public event EventHandler OnMousePressed_Jump;
        public event EventHandler OnMousePressed_Dash;
        public EventHandler OnMousePressed_Slide;

        private readonly int splitScreenY = Screen.height / 2;
        private readonly int splitScreenX = Screen.width / 2;

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
                        //OnMousePressed_StartRun?.Invoke(this, EventArgs.Empty);
                    }

                    if (Input.mousePosition.y >= splitScreenY && Input.mousePosition.x <= splitScreenX)
                    {
                        characterControl.Jump = true;
                        //  OnMousePressed_Jump?.Invoke(this, EventArgs.Empty);
                    }
                    else if (Input.mousePosition.y < splitScreenY && Input.mousePosition.x <= splitScreenX)
                    {
                        //OnMousePressed_Slide?.Invoke(this, EventArgs.Empty);
                        characterControl.Slide = true;
                        StartCoroutine(TurnOff(0.25f));
                    }
                    else if (Input.mousePosition.x > splitScreenX)
                    {
                        characterControl.Dash = true;
                        //OnMousePressed_Dash?.Invoke(this, EventArgs.Empty);
                    }
                }
                else
                {
                    characterControl.Jump = false;
                    characterControl.Dash = false;
                }
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