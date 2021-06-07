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
            RunMode_Input();
            FightMode_Input();
        }

        private void RunMode_Input()
        {
            if(InputManger.Instance.isStarted)
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
        private void FightMode_Input()
        {
            if (control.fightingSystem.FightMod)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    control.Walk = true;
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    control.Walk = true;
                }
                else
                {
                    control.Walk = false;

                }
            }
        }
    }
}