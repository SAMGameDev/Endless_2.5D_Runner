using UnityEngine;

namespace EndlessRunning
{
    public class FPSDisplay : MonoBehaviour
    {
        // private float deltaTime = 0.0f
        private void Start()
        {
            Time.timeScale = 0.3f;
        }
        #region FPS Display
        //private void Update()
        //{
        //    deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        //}

        //private void OnGUI()
        //{
        //    int w = Screen.width, h = Screen.height;

        //    GUIStyle style = new GUIStyle();

        //    Rect rect = new Rect(0, 0, w, h * 2 / 100);
        //    style.alignment = TextAnchor.UpperCenter;
        //    style.fontSize = h * 4 / 100;
        //    style.normal.textColor = Color.red; //new Color(5f, 5f, 5f, 1.0f);
        //    float msec = deltaTime * 1000.0f;
        //    float fps = 1.0f / deltaTime;
        //    string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        //    GUI.Label(rect, text, style);
        //}
        #endregion
    }
}