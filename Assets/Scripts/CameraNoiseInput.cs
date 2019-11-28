using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNoiseInput : MonoBehaviour
{
    Cinemachine.CinemachineImpulseSource impulseSource;

    void Start()
    {
        impulseSource = GetComponent<Cinemachine.CinemachineImpulseSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            impulseSource.GenerateImpulse();
        }
    }
}
