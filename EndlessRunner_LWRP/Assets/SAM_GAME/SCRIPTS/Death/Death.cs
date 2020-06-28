using UnityEngine;

namespace RunnerGame
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
            if (Control.Death)
            {
                // Control.anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("DeathAnimator");
                Control.anim.SetBool(HashManger.Instance.DicMainParameters[TranistionParemeters.Die], true);
                Control.Death = false;
            }
        }
    }
}