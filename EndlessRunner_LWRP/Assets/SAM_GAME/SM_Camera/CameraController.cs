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
        GameObject CamFollow;
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
        private void Awake()
        {
            CinemachineVirtualCamera[] arr;

            arr = FindObjectsOfType<CinemachineVirtualCamera>();

            if (CamFollow == null)
            {
                CamFollow = GameObject.FindGameObjectWithTag("CamFollow"); ;
            }

            foreach (CinemachineVirtualCamera virtualCameras in arr)
            {
                virtualCameras.LookAt = CamFollow.transform;
                virtualCameras.Follow = CamFollow.transform;
            }
        }

        public void TriggerCamera(CameraTrigger trigger)
        {
            ANIMATOR.SetTrigger(trigger.ToString());
        }
    }
}

