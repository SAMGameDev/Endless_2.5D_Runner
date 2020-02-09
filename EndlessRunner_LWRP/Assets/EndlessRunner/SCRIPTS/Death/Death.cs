using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class Death : MonoBehaviour
    {
        protected CharacterControl Control;

        // Start is called before the first frame update
        void Start()
        {
            Control = GetComponent<CharacterControl>();
        }
        // Update is called once per frame
        void Update()
        {
            if (Control.Death)
            {
                // Control.anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("DeathAnimator");
                Control.TurnOnRagdoll();
            }
        }
    }
}
