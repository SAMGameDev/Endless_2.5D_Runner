﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace RunnerGame
{
    public class FindCamFollow : MonoBehaviour
    {
        private GameObject CamFollow;
        private Transform followTarget;
        private CinemachineVirtualCamera Cvm;
        void Awake()
        {
            Cvm = GetComponent<CinemachineVirtualCamera>();
        }

        void Update()
        {
            if (CamFollow == null)
            {
                CamFollow = GameObject.FindGameObjectWithTag("CamFollow"); ;
            }
            followTarget = CamFollow.transform;
            Cvm.LookAt = followTarget;
            Cvm.Follow = followTarget;
        }
    }
}
