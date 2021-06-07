using System.Collections;
using UnityEngine;

namespace EndlessRunning
{
    public class MobileInput : MonoBehaviour
    {
        private int splitScreenY = Screen.height / 2;
        private int splitScreenX = Screen.width / 2;

        public CharacterControl Control;

        private void Awake()
        {
            Control = FindObjectOfType<CharacterControl>();
        }

        void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (!InputManger.Instance.StartRun)
                {
                    InputManger.Instance.StartRun = true;
                }
                if (Input.mousePosition.y >= splitScreenY && Input.mousePosition.x <= splitScreenX)
                {
                    InputManger.Instance.Jump = true;
                }
                else if (Input.mousePosition.y < splitScreenY && Input.mousePosition.x <= splitScreenX)
                {
                    InputManger.Instance.Slide = true;
                    StartCoroutine(TurnOff(0.2f));
                }
                else if (Input.mousePosition.x > splitScreenX)
                {
                    InputManger.Instance.Dash = true;
                }

            }
            else
            {
                InputManger.Instance.Jump = false;
                InputManger.Instance.Dash = false;
                InputManger.Instance.Slide = false;
            }
        }

        private IEnumerator TurnOff(float time)
        {
            yield return new WaitForSeconds(time);

            if (InputManger.Instance.Slide)
            {
                InputManger.Instance.Slide = false;
            }
        }
    }

}

