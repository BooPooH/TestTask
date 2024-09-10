using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f; // Чувствительность мыши

    private float xRotation = 0f; // Текущая ротация по оси X

    void Start()
    {
        // Блокируем курсор в центре экрана и скрываем его
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Получаем значения движения мыши по осям X и Y
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Ограничиваем вертикальное вращение, чтобы не переворачиваться
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Вращаем камеру по оси X (вверх-вниз)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Вращаем игрока по оси Y (влево-вправо)
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
