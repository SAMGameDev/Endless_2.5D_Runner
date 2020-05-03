using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMove : MonoBehaviour
{
    public CharacterController c_Controller;
    Vector3 movedir = Vector3.zero;
    void Start()
    {
        c_Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (c_Controller.isGrounded)
        {
            movedir = new Vector3(Input.GetAxis("Horizontal"), 0.0f,
                Input.GetAxis("Vertical"));
            movedir *= 25f;

            if (Input.GetKey(KeyCode.Space))
            {
                movedir.y = 17;
            }
        }
        else
        {
            movedir.y -= 25 * Time.deltaTime;
        }

        c_Controller.Move(movedir * Time.deltaTime);



    }
}
