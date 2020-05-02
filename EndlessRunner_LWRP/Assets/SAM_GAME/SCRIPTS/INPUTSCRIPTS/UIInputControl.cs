using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RunnerGame
{
    public class UIInputControl : MonoBehaviour
    {
        [SerializeField] private CharacterControl control;
        private void Awake()
        {
            control = GetComponent<CharacterControl>();
        }

        private void Update()
        {
            Time.timeScale = 0.15f;
        }

        #region Jump
        public void OnJumpPressed()
        {
            if (!control.Start)
            {
                control.Start = true;
            }
            else
            {
                control.clickCount++;
                control.Jump = true;
                StartCoroutine(TurnOff(0.05f));
            }
           
        }
        public void OnJumpReleased()
        {
            control.Jump = false;
        }
        #endregion

        #region Dash
        public void OnDashPressed()
        {
            if (!control.Start)
            {
                control.Start = true;
            }
            else
            {
                control.Dash = true;
                CameraManger.Instance.ShakeCamera(0.03f);
            }
        }
        public void OnDashReleased()
        {
            control.Dash = false;
        }
        #endregion

        public void OnSlidePressed()
        {
            if (!control.Start)
            {
                control.Start = true;
            }
            else
            {
                control.Slide = true;
                StartCoroutine(TurnOff(0.25f));
            }         
        }
        public void OnSlideReleased()
        {
            control.Slide = false;
        }

        IEnumerator TurnOff(float time)
        {
            yield return new WaitForSeconds(time);
            Debug.Log("it worked");
            if (control.Slide)
            {
                control.Slide = false;
            }
            else if (control.Jump)
            {
                control.Jump = false;
            }

        }
    }
}
