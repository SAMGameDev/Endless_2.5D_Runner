using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class SwipeControl : MonoBehaviour
    {
        public Vector2 fingerDownPos;
        public Vector2 fingerUpPos;
        public bool detectSwipeAfterRelase = false;
        public float SWIPE_THRESHOLD = 20f;

        private CharacterControl control;

        private void Awake()
        {
            control = GetComponent<CharacterControl>();
        }
        void Update()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    fingerDownPos = touch.position;
                    fingerUpPos = touch.position;
                }

                //Detects Swipe while finger is still moving

                if (touch.phase == TouchPhase.Moved)
                {
                    if (!detectSwipeAfterRelase)
                    {
                        fingerDownPos = touch.position;
                    }
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    fingerDownPos = touch.position;
                }
            }
        }

        float VerticalMoveValue()
        {
            return Mathf.Abs(fingerDownPos.y - fingerUpPos.y);
        }

        float HorizontalMoveValue()
        {
            return Mathf.Abs(fingerDownPos.x - fingerUpPos.x);
        }

        void DetectSwipe()
        {
            if (VerticalMoveValue() > SWIPE_THRESHOLD && VerticalMoveValue() > HorizontalMoveValue())
            {
                Debug.Log("Vertical Swipe Detected!");
                if (fingerDownPos.y - fingerUpPos.y > 0)
                {
                    OnSwipeUp();
                }
                else if (fingerDownPos.y - fingerUpPos.y < 0)
                {
                    OnSwipeDown();
                }
                fingerUpPos = fingerDownPos;

            }
            else if (HorizontalMoveValue() > SWIPE_THRESHOLD && HorizontalMoveValue() > VerticalMoveValue())
            {
                Debug.Log("Horizontal Swipe Detected!");
                if (fingerDownPos.x - fingerUpPos.x > 0)
                {
                    OnSwipeRight();
                }
                // else if (fingerDownPos.x - fingerUpPos.x < 0)
                //{
                //  OnSwipeLeft();
                //}
                fingerUpPos = fingerDownPos;

            }
            else
            {
                Debug.Log("No Swipe Detected!");
            }
        }

        void OnSwipeUp()
        {
            Debug.Log("Swiped Up");
        }

        void OnSwipeDown()
        {
            Debug.Log("Swiped down");
        }
        //  void OnSwipeLeft()
        // {
        //  //Do something when swiped left
        //  }

        void OnSwipeRight()
        {
            //Do something when swiped right
        }
    }
}
