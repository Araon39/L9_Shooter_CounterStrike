using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    // Публичная переменная для хранения максимального здоровья игрока
    public float maxHealth = 100f;

    // Приватная переменная для хранения текущего здоровья игрока
    private float currentHealth;

    // Публичная переменная для хранения ссылки на текстовый элемент UI
    public Text healthText;

    // Метод Start вызывается перед первым кадром
    private void Start()
    {
        // Инициализация текущего здоровья максимальным значением
        currentHealth = maxHealth;

        // Обновление текстового элемента UI
        UpdateHealthUI();
    }

    // Метод для получения урона
    public void TakeDamage(float damage)
    {
        // Уменьшение текущего здоровья на величину урона
        currentHealth -= damage;
        Debug.Log("Игрок получил урон. Текущее здоровье: " + currentHealth);

        // Обновление текстового элемента UI
        UpdateHealthUI();

        // Проверка, не стало ли здоровье меньше или равно нулю
        if (currentHealth <= 0)
        {
            // Если здоровье меньше или равно нулю, вызываем метод Die
            Die();
        }
    }

    // Метод для обработки смерти игрока
    private void Die()
    {
        Debug.Log("Игрок умер.");
        // Перезапуск текущего уровня
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Метод для обновления текстового элемента UI
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            // Обновление текста здоровья
            healthText.text = "Здоровье: " + currentHealth.ToString();
        }
    }
}
