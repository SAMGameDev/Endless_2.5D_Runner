using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Transform CamTransform;
    private Vector3 LastCamPos;
    void Start()
    {
        LastCamPos = CamTransform.position;
    }
    void LateUpdate()
    {
        Vector3 deltaPos = CamTransform.position - LastCamPos;
        float EffectMultiplier = 0.78f;
        transform.position += deltaPos * EffectMultiplier;
        LastCamPos = CamTransform.position;
    }
}
