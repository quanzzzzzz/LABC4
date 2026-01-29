using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float sensitivity = 100f;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Xoay dọc (pitch)
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Xoay ngang (yaw) trực tiếp trên chính camera (không dùng parent)
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX, Space.World);
    }
}