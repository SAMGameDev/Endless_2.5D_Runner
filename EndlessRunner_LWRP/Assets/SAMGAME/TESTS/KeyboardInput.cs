using UnityEngine;

namespace EndlessRunning
{
    #if UNITY_STANDALONE_WIN
    public class KeyboardInput : MonoBehaviour
    {
        public CharacterControl Character;
        void Start()
        {
            Character = GetComponent<CharacterControl>();
        }
        void Update()
        {
            if (Character.isStarted)
            {
                if (Input.GetKeyUp(KeyCode.Return))
                {
                    if (!Character.StartRun)
                    {
                        Character.StartRun = true;
                    }
                }
                else if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
                {
                    Character.Jump = true;
                }
                else
                {
                    Character.Jump = false;
                }
                if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
                {
                    Character.Dash = true;
                }
                else
                {
                    Character.Dash = false;
                }
                if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
                {
                    Character.Slide = true;
                }
                else
                {
                    Character.Slide = false;
                }
            }
        }
    }
#endif
}

