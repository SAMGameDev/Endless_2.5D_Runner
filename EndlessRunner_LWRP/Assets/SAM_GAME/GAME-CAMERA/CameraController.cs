using Cinemachine;
using System.Collections;
using UnityEngine;

namespace EndlessRunning
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
        [SerializeField] protected CacheCharacterControl CachedControl;

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

        public void Start()
        {
            InitialCameraSetUp();
            StartCoroutine(CameraStopper(0.05f));

        }

        //assign follow object when game starts
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
        }

        //check if player is dead, if it is unassign follow object/ stop following
        private IEnumerator CameraStopper(float time)
        {
            yield return new WaitForSeconds(time);

            if (CachedControl.GetCharacterControl.Death)
            {
                foreach (CinemachineVirtualCamera cams in VirtualCameras)
                {
                    if (cams.LookAt != null && cams.Follow != null)
                    {
                        cams.LookAt = null;
                        cams.Follow = null;
                    }
                }
                StopAllCoroutines();
            }
            else
            {
                StartCoroutine(CameraStopper(0.15f));
            }
        }
        public void TriggerCamera(CameraTriggers trigger)
        {
            ANIMATOR.SetTrigger(trigger.ToString());
        }
    }
}