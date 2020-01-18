using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class Death : MonoBehaviour
    {
        public CharacterControl characterControl;
        // Start is called before the first frame update
        void Start()
        {
            characterControl = GetComponent<CharacterControl>();
        }
        // Update is called once per frame
        void Update()
        {
            if (characterControl.Death)
            {
                Debug.Log("I am dead");
                Destroy(this.gameObject);
            }
        }
    }
}
