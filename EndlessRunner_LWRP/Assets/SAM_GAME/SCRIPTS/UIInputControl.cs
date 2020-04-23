using UnityEngine;

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
            Time.timeScale = 0.075f;
        }

        public void OnJumpPressed()
        {
            control.Jump = true;
        }

        public void OnJumpReleased()
        {
            if (!control.Start)
            {
                control.Start = true;
            }

            control.Jump = false;
        }

        public void OnDashPressed()
        {
            control.Dash = true;
        }
        public void OnDashReleased()
        {
            if (!control.Start)
            {
                control.Start = true;
            }
            control.Dash = false;
        }

        public void OnSlidePressed()
        {
            control.Slide = true;
        }

        public void OnSlideReleased()
        {
            if (!control.Start)
            {
                control.Start = true;
            }
            control.Slide = false;
        }
    }
}
