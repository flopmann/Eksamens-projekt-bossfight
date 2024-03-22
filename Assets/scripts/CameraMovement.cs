using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    

    [Header("Field of view")]
    [SerializeField] Camera kamera;
    [SerializeField] bool dynamicFov;



    private void Start()
    {
        
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        DynamicFov();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void DynamicFov()
    {
        if(Input.GetKey(KeyCode.LeftShift)&& dynamicFov == true)
        {
            kamera.fieldOfView = Mathf.Lerp(kamera.fieldOfView,100,10f*Time.deltaTime);
        }
        else
        {
            kamera.fieldOfView = Mathf.Lerp(kamera.fieldOfView, 80, 10f * Time.deltaTime);
        }
         
    }

}
