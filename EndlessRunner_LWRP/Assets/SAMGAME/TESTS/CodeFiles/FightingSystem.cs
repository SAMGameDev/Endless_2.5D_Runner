using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;

namespace EndlessRunning
{
    public class FightingSystem : MonoBehaviour
    {
        public event EventHandler<MyEventaArgs> OnFightHit;

        [SerializeField]
        private Animator anim;

        private void Start()
        {
            anim = GetComponentInChildren<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "FightTrigger")
            {
                OnFightHit?.Invoke(this, new MyEventaArgs { anim = anim });
            }
        }
    }

    public class MyEventaArgs
    {
        public Animator anim;
    }
}

