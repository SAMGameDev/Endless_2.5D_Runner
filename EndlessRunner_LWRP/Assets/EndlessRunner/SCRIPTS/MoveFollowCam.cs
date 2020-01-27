using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFollowCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * 15f * Time.deltaTime);
    }
}
