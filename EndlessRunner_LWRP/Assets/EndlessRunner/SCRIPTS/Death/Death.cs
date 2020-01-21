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
                Control.RIGIDBODY.velocity = Vector3.zero;
                Control.RIGIDBODY.AddForce(-Vector3.forward * 11.5f, ForceMode.VelocityChange);
                Control.anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("DeathAnimator");
            }
        }
    }
}
