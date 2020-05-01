using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class CameraManger : Singleton<CameraManger>
    {
        private Coroutine routine;

        [SerializeField] private CameraController camController;

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

