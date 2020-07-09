using UnityEngine;
using Cinemachine;

namespace EndlessRunning
{
    public class CamControllercustomize : MonoBehaviour
    {
        public CinemachineVirtualCamera vcam;
        
        private void Start()
        {
            Transform camfollow = GameObject.FindGameObjectWithTag("CamFollow").transform;
            vcam.LookAt = camfollow;
            vcam.Follow = camfollow;
        }
    }
}

