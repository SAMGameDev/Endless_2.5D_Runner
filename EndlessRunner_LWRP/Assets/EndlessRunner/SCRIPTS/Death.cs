using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class Death : MonoBehaviour
    {
        [SerializeField]
        private CharacterControl Control;
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
                Control.RIGIDBODY.AddForce(-Vector3.forward * 3000, ForceMode.Force);              
                Control.anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("DeathAnimator");
            }
        }
    }
}
