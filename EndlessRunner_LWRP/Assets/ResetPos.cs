using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class ResetPos : StateMachineBehaviour
    {
        public Transform GetTransform;
        private Vector3 pos;
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GetTransform = animator.GetComponent<Transform>();
            pos = GetTransform.position;
        }


        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GetTransform.position = pos;
        }

    }
}

