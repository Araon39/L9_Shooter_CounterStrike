using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    // ���������� ��� �������� �������� �������
    public float health = 50;
    private float maxHealth;

    // ��������� ���������� ��� �������� ������ �� ������� ��������
    public Slider healthBar;

    // ���������� ��� �������� ������ �� ������
    private Camera mainCamera;

    // ��������� ���������� ��� �������� ������ �� ��������� Animator
    private Animator animator;

    private void Start()
    {
        // �������������� ������������ ��������
        maxHealth = health;

        // �������� ������ �� �������� ������
        mainCamera = Camera.main;

        // �������� ��������� Animator
        animator = GetComponent<Animator>();

        // �������������� ������� ��������
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = health;
        }
        else
        {
            Debug.LogError("������� �������� �� �������� � ����������.");
        }
    }

    private void Update()
    {
        // ��������� ������� �������� ��������
        if (healthBar != null && mainCamera != null)
        {
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(transform.position + Vector3.up * 2);
            healthBar.transform.position = screenPosition;
        }
    }

    // ����� ��� ��������� �����
    public void TakeDamage(float amount)
    {
        // ��������� �������� �� �������� �����
        health -= amount;

        // ������������� �������� ��������� �����
        if (animator != null)
        {
            animator.SetTrigger("hit");
        }

        // ��������� ������� ��������
        UpdateHealthBar();

        // ���������, �� ����� �� �������� ������ ��� ����� ����
        if (health <= 0)
        {
            // ���� �������� ������ ��� ����� ����, �������� ����� Die
            Die();
        }
    }

    // ����� ��� ���������� �������� ��������
    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = health;
        }
    }

    // ����� ��� ����������� �������
    public void Die()
    {
        // ���������� ������� ��������
        if (healthBar != null)
        {
            Destroy(healthBar.gameObject);
        }

        // ������������� �������� ������
        if (animator != null)
        {
            animator.SetTrigger("die");
        }

        // ��������� ��� �������� �����
        this.enabled = false;

        // ���������� ������
        Destroy(gameObject, 6f); // ���������� ������ � ���������, ����� �������� ������ ������ ���������������
    }
}
