using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LookAtCamera : MonoBehaviour
{
    Transform cameraTransform;

    void Awake ()
    {
        cameraTransform = Camera.main.transform;
    }
	
	void Update ()
    {
        transform.LookAt(cameraTransform);
        var rotation = transform.localEulerAngles;
        rotation.y = -180;
        transform.localEulerAngles = rotation;
    }
}
