using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 1000f;
    public float xsens = 700f;
    public Transform body;
    public Transform buddy;
    float xrotation = 0f;
    public Transform hammer;
    public TMP_Text scoretext, menutext1, menutext2;
    private bool inmenu = true;
    public Image menu1, menu2;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        if (inmenu) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                inmenu = false;
                hammer.gameObject.SetActive(true);
                body.position = new Vector3(2.24f, 1.46f, 0);
                scoretext.text = "SCORE: 0";
                menutext1.text = ""; menutext2.text = "";
                menu1.gameObject.SetActive(true); menu2.gameObject.SetActive(true);
            }
        }

        if (!inmenu) {
        float mousex = Input.GetAxis("Mouse X") * xsens * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        
        xrotation -= mousey;
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        body.Rotate(Vector3.up * mousex);
        }
    }
}
