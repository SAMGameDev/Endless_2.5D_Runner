using UnityEngine;
using System;

namespace EndlessRunning
{
    public class TakeInputs : MonoBehaviour
    {
        public event EventHandler OnMousePressed_StartRun;
        public event EventHandler OnMousePressed_Jump;
        public event EventHandler OnMousePressed_Dash;
        public EventHandler OnMousePressed_Slide;

        private readonly int splitScreenY = Screen.height / 2;
        private readonly int splitScreenX = Screen.width / 2;

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                OnMousePressed_StartRun?.Invoke(this, EventArgs.Empty);

                if (Input.mousePosition.y >= splitScreenY && Input.mousePosition.x <= splitScreenX)
                {
                    OnMousePressed_Jump?.Invoke(this, EventArgs.Empty);
                }
                else if (Input.mousePosition.y < splitScreenY && Input.mousePosition.x <= splitScreenX)
                {
                    OnMousePressed_Slide?.Invoke(this, EventArgs.Empty);
                }
                else if (Input.mousePosition.x > splitScreenX)
                {
                    OnMousePressed_Dash?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}