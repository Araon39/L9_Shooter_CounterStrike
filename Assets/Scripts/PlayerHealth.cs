using System.Collections;
using System.Collections.Generic;
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
    // Публичная переменная для хранения ссылки на панель урона
    public Image damagePanel;
    // Публичная переменная для хранения ссылки на текст "Вы умерли"
    public Text deathText;
    // Приватная переменная для хранения исходного цвета панели урона
    private Color originalDamagePanelColor;

    // Метод Start вызывается перед первым кадром
    private void Start()
    {
        // Инициализация текущего здоровья максимальным значением
        currentHealth = maxHealth;

        // Обновление текстового элемента UI
        UpdateHealthUI();

        // Скрываем текст "Вы умерли"
        if (deathText != null)
        {
            deathText.gameObject.SetActive(false);
        }

        // Сохраняем исходный цвет панели урона
        if (damagePanel != null)
        {
            originalDamagePanelColor = damagePanel.color;
        }
    }

    // Метод для получения урона
    public void TakeDamage(float damage)
    {
        // Уменьшение текущего здоровья на величину урона
        currentHealth -= damage;
        Debug.Log("Игрок получил урон. Текущее здоровье: " + currentHealth);

        // Обновление текстового элемента UI
        UpdateHealthUI();

        // Обновление панели урона
        UpdateDamagePanel();

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

        // Останавливаем игру
        Time.timeScale = 0f;

        // Отображаем текст "Вы умерли"
        if (deathText != null)
        {
            deathText.gameObject.SetActive(true);
        }

        // Запускаем корутину для перезапуска уровня через 5 секунд
        StartCoroutine(RestartLevelCoroutine());
    }

    // Корутин для перезапуска уровня
    private IEnumerator RestartLevelCoroutine()
    {
        // Ждем 5 секунд
        yield return new WaitForSecondsRealtime(5f);

        // Возвращаем нормальную скорость игры
        Time.timeScale = 1f;

        // Восстанавливаем UI здоровье
        if (damagePanel != null)
        {
            damagePanel.color = originalDamagePanelColor;
        }

        // Скрываем текст "Вы умерли"
        if (deathText != null)
        {
            deathText.gameObject.SetActive(false);
        }

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

    // Метод для обновления панели урона
    private void UpdateDamagePanel()
    {
        if (damagePanel != null)
        {
            // Вычисляем процент урона
            float damagePercent = 1 - (currentHealth / maxHealth);

            // Обновляем цвет панели урона
            Color newColor = originalDamagePanelColor;
            newColor.a = damagePercent;
            damagePanel.color = newColor;
        }
    }
}
