using UnityEngine;

namespace EndlessRunning
{
    public class Death : MonoBehaviour
    {
        private CharacterControl Control;

        private void Awake()
        {
            Control = GetComponent<CharacterControl>();
        }

        private void Update()
        {
            if (!Control.isStarted) return;

            switch (Control.Death)
            {
                case true:
                    Control.anim.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Die], true);
                    break;

                case false:
                    Control.anim.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Die], false);
                    break;
            }
        }
    }
}