using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class Death : MonoBehaviour
    {
        protected CharacterControl Control;

        void Start()
        {
            Control = GetComponent<CharacterControl>();
        }
        void Update()
        {
            if (Control.Death)
            {
                Control.anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("DeathAnimator");
            }
        }
    }
}
