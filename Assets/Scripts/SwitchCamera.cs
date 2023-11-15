using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera[] virtualCameras;
    public int _currentCamera = 0;


    void Start()
    {
    }

    void Update()
    {
        var lastSize = virtualCameras[_currentCamera].m_Lens.OrthographicSize;
        // Camera Distance
        if (Input.GetKeyDown("q")) {
            virtualCameras[_currentCamera].m_Lens.OrthographicSize += 1f;
        }

        if (Input.GetKeyDown("e")) {
            virtualCameras[_currentCamera].m_Lens.OrthographicSize -= 1f;
        }

        // Space
        bool changeCamera = Input.GetButtonDown("Jump");
        if (changeCamera && virtualCameras.Length > _currentCamera)
        {
            _currentCamera = (_currentCamera + 1) % virtualCameras.Length;
            virtualCameras[_currentCamera].MoveToTopOfPrioritySubqueue();
        }
    }
}
