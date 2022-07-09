using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 1000f;
    public float xsens = 700f;
    public Transform body;
    public Transform buddy;
    float xrotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mousex = Input.GetAxis("Mouse X") * xsens * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        
        xrotation -= mousey;
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        body.Rotate(Vector3.up * mousex);
    }
}
