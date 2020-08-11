using Cinemachine;
using UnityEngine;

namespace EndlessRunning
{
    public class MenuCamController : MonoBehaviour
    {
        public CinemachineVirtualCamera virtualCamera;
        public Transform camF;

        public void Start()
        {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
            camF = GameObject.FindGameObjectWithTag("CamFollow").transform;
            virtualCamera.LookAt = camF;
            virtualCamera.Follow = camF;
        }
    }
}

