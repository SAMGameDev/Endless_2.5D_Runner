using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace RunnerGame
{
    public enum CameraTrigger
    {
        Default,
        Shake,
    }
    public class CameraController : MonoBehaviour
    {
        private Animator animator;
        public Animator ANIMATOR
        {
            get
            {
                if (animator == null)
                {
                    animator = GetComponent<Animator>();
                }
                return animator;
            }
        }
       // private GameObject CamFollow;
       // private Transform followTarget;
        
       /* void Update()
        {
            if (CamFollow == null)
            {
                CamFollow = GameObject.FindGameObjectWithTag("CamFollow"); ;
            }
            followTarget = CamFollow.transform;          
            statDrive.LookAt = followTarget;
            statDrive.Follow = followTarget;
        }*/

        public void TriggerCamera(CameraTrigger trigger)
        {
            ANIMATOR.SetTrigger(trigger.ToString());
        }
    }
}

