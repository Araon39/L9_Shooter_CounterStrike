using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    // ��������� ���������� ��� �������� ������������� �������� ������
    public float maxHealth = 100f;

    // ��������� ���������� ��� �������� �������� �������� ������
    private float currentHealth;

    // ��������� ���������� ��� �������� ������ �� ��������� ������� UI
    public Text healthText;

    // ����� Start ���������� ����� ������ ������
    private void Start()
    {
        // ������������� �������� �������� ������������ ���������
        currentHealth = maxHealth;

        // ���������� ���������� �������� UI
        UpdateHealthUI();
    }

    // ����� ��� ��������� �����
    public void TakeDamage(float damage)
    {
        // ���������� �������� �������� �� �������� �����
        currentHealth -= damage;
        Debug.Log("����� ������� ����. ������� ��������: " + currentHealth);

        // ���������� ���������� �������� UI
        UpdateHealthUI();

        // ��������, �� ����� �� �������� ������ ��� ����� ����
        if (currentHealth <= 0)
        {
            // ���� �������� ������ ��� ����� ����, �������� ����� Die
            Die();
        }
    }

    // ����� ��� ��������� ������ ������
    private void Die()
    {
        Debug.Log("����� ����.");
        // ���������� �������� ������
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // ����� ��� ���������� ���������� �������� UI
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            // ���������� ������ ��������
            healthText.text = "��������: " + currentHealth.ToString();
        }
    }
}
