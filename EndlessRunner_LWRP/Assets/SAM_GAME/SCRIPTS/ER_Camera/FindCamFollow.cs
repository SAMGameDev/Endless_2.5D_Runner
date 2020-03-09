using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace RunnerGame
{
    public class FindCamFollow : MonoBehaviour
    {
        private GameObject CamFollow;
        private Transform followTarget;
        private CinemachineVirtualCamera cinemaMachine_virtualCamera;
        void Start()
        {
            cinemaMachine_virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        void Update()
        {
            if (CamFollow == null)
            {
                CamFollow = GameObject.FindGameObjectWithTag("CamFollow"); ;
            }
            followTarget = CamFollow.transform;
            cinemaMachine_virtualCamera.LookAt = followTarget;
            cinemaMachine_virtualCamera.Follow = followTarget;
        }
    }
}

