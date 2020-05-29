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
                CameraManger.Instance.ShakeCamera(0.3f);
                Control.anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("DeathAnimator");
                AudioManger.instance.SoundPlay("Death");
            }
        }
    }
}