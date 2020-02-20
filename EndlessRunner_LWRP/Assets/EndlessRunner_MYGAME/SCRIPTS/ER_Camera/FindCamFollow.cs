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
        private CinemachineTransposer cinemachine_Transposer;
        void Awake()
        {
            cinemaMachine_virtualCamera = GetComponent<CinemachineVirtualCamera>();
            cinemachine_Transposer = cinemaMachine_virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            cinemachine_Transposer.m_FollowOffset = new Vector3(22, 2, 0);
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

