using System.Collections;
using UnityEngine;

namespace EndlessRunning
{
    public class CameraManger : Singleton<CameraManger>
    {
        public Camera mainCamera;
        private Coroutine routine;
        public CameraController Game_CamController;

        public CameraController CAMERACONTROLLER
        {
            get
            {
                if (Game_CamController == null)
                {
                    Game_CamController = FindObjectOfType<CameraController>();
                }
                return Game_CamController;
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