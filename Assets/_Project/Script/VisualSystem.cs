using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualSystem : MonoBehaviour
{
    [Header("Visual Settings")]
    [SerializeField]
    private float mouseSensitivity = 1000f;
    [SerializeField]
    private Transform cameraPivot;

    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Look();
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);
        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -35f, 50f);

        cameraPivot.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
    }
}
