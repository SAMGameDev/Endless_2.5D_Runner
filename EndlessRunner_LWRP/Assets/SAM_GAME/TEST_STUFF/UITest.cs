using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class UITest : MonoBehaviour
    {
        int splitScreen = Screen.height / 2;
        int spitscreenHori = Screen.width / 2;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) &&
               Input.mousePosition.y >= splitScreen &&
               Input.mousePosition.x <= spitscreenHori)
            {
                Debug.Log("Top");
            }
            else if (Input.GetMouseButtonUp(0) 
                && Input.mousePosition.y < splitScreen 
                && Input.mousePosition.x <= spitscreenHori)
            {
                Debug.Log("bottom");
            }
            else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > spitscreenHori)
            {
                Debug.Log("right");
            }
        }
    }
}

