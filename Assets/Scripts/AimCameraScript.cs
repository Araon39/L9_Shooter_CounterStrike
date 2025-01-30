using UnityEngine;

public class AimCameraScript : MonoBehaviour
{
    // Объявление переменных для основной и прицельной камер
    public Camera mainCamera;
    public Camera aimCamera;

    // Метод Update вызывается каждый кадр
    void Update()
    {
        // Проверка, нажата ли левая кнопка мыши (код кнопки 1)
        if (Input.GetMouseButtonDown(1))
        {
            // Отключение основной камеры и включение прицельной камеры
            mainCamera.enabled = false;
            aimCamera.enabled = true;
        }

        // Проверка, отпущена ли левая кнопка мыши (код кнопки 1)
        if (Input.GetMouseButtonUp(1))
        {
            // Включение основной камеры и отключение прицельной камеры
            mainCamera.enabled = true;
            aimCamera.enabled = false;
        }
    }
}
