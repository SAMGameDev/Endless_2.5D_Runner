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
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject CamFollow;
        [SerializeField] private CinemachineVirtualCamera[] arr;
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
            arr = GameObject.FindObjectsOfType<CinemachineVirtualCamera>();

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

