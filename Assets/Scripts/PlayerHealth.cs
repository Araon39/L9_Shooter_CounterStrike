using System.Collections;
using System.Collections.Generic;
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
    // ��������� ���������� ��� �������� ������ �� ������ �����
    public Image damagePanel;
    // ��������� ���������� ��� �������� ������ �� ����� "�� ������"
    public Text deathText;
    // ��������� ���������� ��� �������� ��������� ����� ������ �����
    private Color originalDamagePanelColor;

    // ����� Start ���������� ����� ������ ������
    private void Start()
    {
        // ������������� �������� �������� ������������ ���������
        currentHealth = maxHealth;

        // ���������� ���������� �������� UI
        UpdateHealthUI();

        // �������� ����� "�� ������"
        if (deathText != null)
        {
            deathText.gameObject.SetActive(false);
        }

        // ��������� �������� ���� ������ �����
        if (damagePanel != null)
        {
            originalDamagePanelColor = damagePanel.color;
        }
    }

    // ����� ��� ��������� �����
    public void TakeDamage(float damage)
    {
        // ���������� �������� �������� �� �������� �����
        currentHealth -= damage;
        Debug.Log("����� ������� ����. ������� ��������: " + currentHealth);

        // ���������� ���������� �������� UI
        UpdateHealthUI();

        // ���������� ������ �����
        UpdateDamagePanel();

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

        // ������������� ����
        Time.timeScale = 0f;

        // ���������� ����� "�� ������"
        if (deathText != null)
        {
            deathText.gameObject.SetActive(true);
        }

        // ��������� �������� ��� ����������� ������ ����� 5 ������
        StartCoroutine(RestartLevelCoroutine());
    }

    // ������� ��� ����������� ������
    private IEnumerator RestartLevelCoroutine()
    {
        // ���� 5 ������
        yield return new WaitForSecondsRealtime(5f);

        // ���������� ���������� �������� ����
        Time.timeScale = 1f;

        // ��������������� UI ��������
        if (damagePanel != null)
        {
            damagePanel.color = originalDamagePanelColor;
        }

        // �������� ����� "�� ������"
        if (deathText != null)
        {
            deathText.gameObject.SetActive(false);
        }

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

    // ����� ��� ���������� ������ �����
    private void UpdateDamagePanel()
    {
        if (damagePanel != null)
        {
            // ��������� ������� �����
            float damagePercent = 1 - (currentHealth / maxHealth);

            // ��������� ���� ������ �����
            Color newColor = originalDamagePanelColor;
            newColor.a = damagePercent;
            damagePanel.color = newColor;
        }
    }
}
