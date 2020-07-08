using System.Collections;
using UnityEngine;

namespace EndlessRunning
{
    public class CameraManger : Singleton<CameraManger>
    {
        private Coroutine routine;
        public Camera mainCamera;
        public CameraController camController;

        public CameraController CAMERACONTROLLER
        {
            get
            {
                if (camController == null)
                {
                    camController = FindObjectOfType<CameraController>();
                }
                return camController;
            }
        }

        private void Awake()
        {
            GameObject camObj = GameObject.FindGameObjectWithTag("MainCamera");
            mainCamera = camObj.GetComponent<Camera>();
        }

        private IEnumerator CamShake(float sec)
        {
            CAMERACONTROLLER.TriggerCamera(CameraTriggers.Shake);
            yield return new WaitForSeconds(sec);
            CAMERACONTROLLER.TriggerCamera(CameraTriggers.Default);
        }

        public void ShakeCamera(float sec)
        {
            if (routine != null)
            {
                StopCoroutine(routine);
            }

            routine = StartCoroutine(CamShake(sec));
        }
    }
}