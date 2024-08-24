using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform cameraHolder;
    float verticalLookRotation;
    float sensitivity;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        sensitivity = StateNameController.sensitivity;
    }

   void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * sensitivity);
        verticalLookRotation -= Input.GetAxisRaw("Mouse Y") * sensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        cameraHolder.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);
    }
}
