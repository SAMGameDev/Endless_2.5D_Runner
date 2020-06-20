using UnityEngine;
using Cinemachine;
using System.Collections;

namespace RunnerGame
{
    public enum CameraTriggers
    {
        Default,
        Shake,
        Slide,
        Jump,
    }
    public class CameraController : MonoBehaviour
    {
        [SerializeField] protected CinemachineVirtualCamera[] VirtualCameras;

        [SerializeField] protected OnStartSetup onStartSetup;

        private Transform CamFollow;

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

        public void Awake()
        {
            InitialCameraSetUp();
        }

        void InitialCameraSetUp()
        {
            VirtualCameras = FindObjectsOfType<CinemachineVirtualCamera>();

            if (CamFollow == null)
            {
                CamFollow = GameObject.FindGameObjectWithTag("CamFollow").transform;
            }

            foreach (CinemachineVirtualCamera virtualCamera in VirtualCameras)
            {
                virtualCamera.LookAt = CamFollow;
                virtualCamera.Follow = CamFollow;
            }

            StartCoroutine(CameraStopper(0f));
        }

        private IEnumerator CameraStopper(float time)
        {
            yield return new WaitForSeconds(time);

            if (onStartSetup.GetCharacterControl.Death)
            {
                foreach (CinemachineVirtualCamera virtualCamera in VirtualCameras)
                {
                    if (virtualCamera.LookAt != null && virtualCamera.Follow != null)
                    {
                        virtualCamera.LookAt = null;
                        virtualCamera.Follow = null;
                    }
                }
                onStartSetup.GetCharacterControl.Death = false;
                StopAllCoroutines();
            }
            else
            {
                StartCoroutine(CameraStopper(0.2f));
            }
        }
        public void TriggerCamera(CameraTriggers trigger)
        {
            ANIMATOR.SetTrigger(trigger.ToString());
        }
    }
}