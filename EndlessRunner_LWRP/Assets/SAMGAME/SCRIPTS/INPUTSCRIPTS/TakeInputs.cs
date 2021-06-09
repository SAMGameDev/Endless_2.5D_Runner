using UnityEngine;

namespace EndlessRunning
{
    public class TakeInputs : MonoBehaviour
    {
        [SerializeField]
        private CharacterControl control;

        private void Awake()
        {
            control = GetComponent<CharacterControl>();
        }

        private void Update()
        {
            AnimationControl();
        }

        private void AnimationControl()
        {
            if (InputManger.Instance.StartRun)
            {
                control.StartRun = true;
            }
            else
            {
                control.StartRun = false;
            }
            if (InputManger.Instance.Jump)
            {
                control.Jump = true;
            }
            else
            {
                control.Jump = false;
            }
            if (InputManger.Instance.Slide)
            {
                control.Slide = true;
            }
            else
            {
                control.Slide = false;
            }
            if (InputManger.Instance.Dash)
            {
                control.Dash = true;
            }
            else
            {
                control.Dash = false;
            }
        }
    }
}