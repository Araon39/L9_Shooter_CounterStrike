using UnityEngine;

public class PC : MonoBehaviour
{
    // Объявление переменной для хранения ссылки на CharacterController
    public UnityEngine.CharacterController controller;

    // Объявление приватных переменных для хранения значений скорости, гравитации и высоты прыжка
    private float speed = 5f;
    private float gravity = -9.81f;
    private float jumpHeight = 5f;

    // Объявление приватной переменной для хранения вектора скорости
    private Vector3 velocity;

    // Метод Update вызывается каждый кадр
    void Update()
    {
        // Получение горизонтального и вертикального ввода от игрока
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Создание вектора движения на основе ввода игрока и направления персонажа
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        // Перемещение персонажа с использованием CharacterController
        controller.Move(move * speed * Time.deltaTime);

        // Проверка, нажата ли клавиша пробела
        if (Input.GetKey(KeyCode.Space))
        {
            // Установка начальной скорости прыжка по оси Y
            velocity.y = jumpHeight;
        }

        // Применение гравитации к скорости по оси Y
        velocity.y += gravity * Time.deltaTime;

        // Перемещение персонажа по оси Y с использованием CharacterController
        controller.Move(velocity * Time.deltaTime);
    }
}
