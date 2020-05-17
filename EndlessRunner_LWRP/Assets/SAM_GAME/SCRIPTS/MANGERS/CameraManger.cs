using System.Collections;
using UnityEngine;

namespace RunnerGame
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
                    camController = GameObject.FindObjectOfType<CameraController>();
                }
                return camController;
            }
        }

        private void Awake()
        {
            GameObject camObj = GameObject.FindGameObjectWithTag("MainCamera");
            mainCamera = camObj.GetComponent<Camera>();
        }

        IEnumerator CamShake(float sec)
        {
            CAMERACONTROLLER.TriggerCamera(CameraTrigger.Shake);
            yield return new WaitForSeconds(sec);
            CAMERACONTROLLER.TriggerCamera(CameraTrigger.Default);
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

