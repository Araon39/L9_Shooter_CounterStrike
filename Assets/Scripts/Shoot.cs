using UnityEngine;

public class Shoot : MonoBehaviour
{
   
    private float range = 100;      // Дальность выстрела   
    public Camera mainCamera;       // Ссылка на основную камеру
    public GameObject bulletEffects;// Префаб пули, который будет инстанцироваться при выстреле   
    public GameObject bulletPoint;  // Префаб дырки от пули, который будет инстанцироваться при попадании    
    public float damage = 10;       // Урон, наносимый пулей

    void Update()
    {
        // Проверяем, нажата ли левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Вызываем метод для обработки выстрела
            Shoots();
        }
    }

    // Метод для обработки выстрела
    private void Shoots()
    {
        // Переменная для хранения информации о попадании луча
        RaycastHit hit;

        // Проверяем, попал ли луч в объект в пределах заданной дальности
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
        {
            // Если попадание произошло, выводим имя объекта, в который попали
            Debug.Log(hit.transform.name);

            // Получаем компонент Target из объекта, в который попал луч
            Target target = hit.transform.GetComponent<Target>();

            // Проверяем, что компонент Target существует
            if (target != null)
            {
                // Если компонент Target существует, наносим урон объекту
                target.TakeDamage(damage);
            }


            // Создаем пулю в точке попадания луча
            GameObject bullet = Instantiate(bulletEffects, hit.point, Quaternion.LookRotation(hit.normal));
            // Создаем дырку от пули в точке попадания луча
            GameObject point = Instantiate(bulletPoint, hit.point, Quaternion.LookRotation(hit.normal));

            // Уничтожаем пулю через 2 секунды
            Destroy(bullet, 2f);
            // Уничтожаем дырку от пули через 10 секунды
            Destroy(point, 10f);
        }
    }
}
