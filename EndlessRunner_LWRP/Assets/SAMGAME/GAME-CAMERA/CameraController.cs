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
        Fight
    }

    public class CameraController : MonoBehaviour
    {
        [SerializeField] protected CinemachineVirtualCamera[] Virtualcameras;
        [SerializeField] protected CacheCharacterControl cachedControl;

        private Transform camFollow;
        public Animator animator;

        private void Start()
        {
            InitialCameraSetUp();
            StartCoroutine(CameraStopper(0.03f));
        }

        //assign follow object when game starts
        private void InitialCameraSetUp()
        {
            Virtualcameras = FindObjectsOfType<CinemachineVirtualCamera>();

            if (camFollow == null)
            {
                camFollow = GameObject.FindGameObjectWithTag("CamFollow").transform;
            }

            foreach (var virtualCamera in Virtualcameras)
            {
                virtualCamera.LookAt = camFollow;
                virtualCamera.Follow = camFollow;
            }
        }

        //check if player is dead, if it is unassign follow object/ stop following
        private IEnumerator CameraStopper(float time)
        {
            yield return new WaitForSeconds(time);

            if (cachedControl.GetCharacterControl.GameOver)
            {
                foreach (var cams in Virtualcameras)
                {
                    cams.LookAt = null;
                    cams.Follow = null;
                }
            }
            else
            {
                StartCoroutine(CameraStopper(0.03f));
            }
        }

        public void TriggerCamera(CameraTriggers trigger)
        {
            animator.SetTrigger(trigger.ToString());
        }
    }
}