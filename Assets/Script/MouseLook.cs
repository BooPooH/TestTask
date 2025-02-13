using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f; // ���������������� ����

    private float xRotation = 0f; // ������� ������� �� ��� X

    void Start()
    {
        // ��������� ������ � ������ ������ � �������� ���
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // �������� �������� �������� ���� �� ���� X � Y
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // ������������ ������������ ��������, ����� �� ����������������
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // ������� ������ �� ��� X (�����-����)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // ������� ������ �� ��� Y (�����-������)
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
