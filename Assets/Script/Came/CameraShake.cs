using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Camera mainCam;
    Vector3 cameraPos;

    [SerializeField]
    [Range(.01f, .1f)] float shakeRange = .05f;
    [SerializeField]
    [Range(.1f, 1f)] float duration = .5f;

    public void Shake()
    {
        cameraPos = mainCam.transform.position;
        InvokeRepeating("StartShake", 0f, .005f);
        Invoke("StopShake", duration);
    }

    void StartShake()
    {
        float cameraPosX = Random.value * shakeRange * 2 - shakeRange;
        float cameraPosY = Random.value * shakeRange * 2 - shakeRange;
        Vector3 cameraPos = mainCam.transform.position;
        cameraPos.x = cameraPosX;
        cameraPos.y = cameraPosY;
        mainCam.transform.position = cameraPos;
    }

    void StopShake()
    {
        CancelInvoke("StartShake");
        mainCam.transform.position = cameraPos;
    }
}
