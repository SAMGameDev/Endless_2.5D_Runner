using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class Death : MonoBehaviour
    {
        public PlayerJump playerJump;
        public GameObject player;

        // Start is called before the first frame update
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
          
        }
         void OnCollisionEnter(Collision collision)
        {
           /* if(playerJump.IsGrounded && collision.gameObject.tag == "Wall" || collision.gameObject.tag == "obstacle")
            {
                Destroy(player);
            }*/
        }
    }

}
