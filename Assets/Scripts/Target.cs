using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    // Переменная для хранения здоровья объекта
    public float health = 50;
    private float maxHealth;

    // Публичная переменная для хранения ссылки на слайдер здоровья
    public Slider healthBar;

    // Переменная для хранения ссылки на камеру
    private Camera mainCamera;

    // Приватная переменная для хранения ссылки на компонент Animator
    private Animator animator;

    private void Start()
    {
        // Инициализируем максимальное здоровье
        maxHealth = health;

        // Получаем ссылку на основную камеру
        mainCamera = Camera.main;

        // Получаем компонент Animator
        animator = GetComponent<Animator>();

        // Инициализируем слайдер здоровья
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = health;
        }
        else
        {
            Debug.LogError("Слайдер здоровья не назначен в инспекторе.");
        }
    }

    private void Update()
    {
        // Обновляем позицию слайдера здоровья
        if (healthBar != null && mainCamera != null)
        {
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(transform.position + Vector3.up * 2);
            healthBar.transform.position = screenPosition;
        }
    }

    // Метод для получения урона
    public void TakeDamage(float amount)
    {
        // Уменьшаем здоровье на величину урона
        health -= amount;

        // Воспроизводим анимацию получения урона
        if (animator != null)
        {
            animator.SetTrigger("hit");
        }

        // Обновляем слайдер здоровья
        UpdateHealthBar();

        // Проверяем, не стало ли здоровье меньше или равно нулю
        if (health <= 0)
        {
            // Если здоровье меньше или равно нулю, вызываем метод Die
            Die();
        }
    }

    // Метод для обновления слайдера здоровья
    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = health;
        }
    }

    // Метод для уничтожения объекта
    public void Die()
    {
        // Уничтожаем слайдер здоровья
        if (healthBar != null)
        {
            Destroy(healthBar.gameObject);
        }

        // Воспроизводим анимацию смерти
        if (animator != null)
        {
            animator.SetTrigger("die");
        }

        // Отключаем все действия врага
        this.enabled = false;

        // Уничтожаем объект
        Destroy(gameObject, 6f); // Уничтожаем объект с задержкой, чтобы анимация смерти успела воспроизвестись
    }
}
