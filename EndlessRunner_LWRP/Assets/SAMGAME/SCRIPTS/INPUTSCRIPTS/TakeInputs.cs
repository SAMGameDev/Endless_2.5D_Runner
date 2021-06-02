using UnityEngine;
using System.Collections;

namespace EndlessRunning
{
    public class TakeInputs : MonoBehaviour
    {
        [SerializeField]
        private CharacterControl control;

        private readonly int splitScreenY = Screen.height / 2;
        private readonly int splitScreenX = Screen.width / 2;

        private void Awake()
        {
            control = GetComponent<CharacterControl>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                if(control.isStarted)
                {
                    if(!control.StartRun)
                    {
                        control.StartRun = true;
                    }
                    if (Input.mousePosition.y >= splitScreenY && Input.mousePosition.x <= splitScreenX)
                    {
                        control.Jump = true;
                    }
                    else if (Input.mousePosition.y < splitScreenY && Input.mousePosition.x <= splitScreenX)
                    {
                        control.Slide = true;
                        StartCoroutine(TurnOff(0.3f));
                    }
                    else if (Input.mousePosition.x > splitScreenX)
                    {
                        control.Dash = true;
                    }
                }     
            }
            else
            {
                control.Jump = false;
                control.Dash = false;
            }
        }

        private IEnumerator TurnOff(float time)
        {
            yield return new WaitForSeconds(time);

            if (control.Slide)
            {
                control.Slide = false;
            }
        }
    }
}