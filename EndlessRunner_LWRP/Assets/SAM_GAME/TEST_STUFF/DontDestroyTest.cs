using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class DontDestroyTest : MonoBehaviour
    {
        public static DontDestroyTest instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(instance);
            }
            else
            {
                Destroy(this);
            }
        }

        private void Update()
        {
            //if (Input.GetMouseButtonDown(0) &&
            //   Input.mousePosition.y >= splitScreen &&
            //   Input.mousePosition.x <= spitscreenHori)
            //{
            //    Debug.Log("Top");
            //}
            //else if (Input.GetMouseButtonUp(0) 
            //    && Input.mousePosition.y < splitScreen 
            //    && Input.mousePosition.x <= spitscreenHori)
            //{
            //    Debug.Log("bottom");
            //}
            //else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > spitscreenHori)
            //{
            //    Debug.Log("right");
            //}
        }
    }
}

