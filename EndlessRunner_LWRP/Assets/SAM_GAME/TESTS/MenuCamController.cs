using Cinemachine;
using UnityEngine;

namespace EndlessRunning
{
    public class MenuCamController : MonoBehaviour
    {
        public CinemachineVirtualCamera virtualCamera;

        public void Start()
        {
            Transform camFollow;
            camFollow = GameObject.FindGameObjectWithTag("CamFollow").transform;
            virtualCamera.LookAt = camFollow;
            virtualCamera.Follow = camFollow;
        }
    }
}