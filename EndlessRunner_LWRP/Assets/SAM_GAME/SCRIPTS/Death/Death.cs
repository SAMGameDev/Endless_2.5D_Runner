using UnityEngine;

namespace EndlessRunning
{
    public class Death : MonoBehaviour
    {
        protected CharacterControl Control;

        private void Start()
        {
            Control = GetComponent<CharacterControl>();
        }

        private void Update()
        {
            switch (Control.Death)
            {
                case true:
                    Control.anim.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Die], true);
                    Control.Death = false;
                    break;
                case false:
                    Control.anim.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Die], false);
                    break;
            }
        }
    }
}

