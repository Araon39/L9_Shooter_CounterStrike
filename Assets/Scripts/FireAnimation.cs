using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimation : MonoBehaviour
{
    // ��������� ���������� ��� �������� ������ �� ������� ������ ����
    public ParticleSystem fire;

    // ��������� ���������� ��� �������� ������ �� ��������� ����
    public AudioClip fireSound;

    // ��������� ���������� ��� �������� ������ �� AudioSource
    private AudioSource audioSource;

    // ����� Start ���������� ����� ������ ������
    void Start()
    {
        // ��������� ���������� AudioSource �� ������� �������
        audioSource = GetComponent<AudioSource>();

        // ��������, �������� �� ���������
        if (fireSound != null)
        {
            // ���������� ���������� AudioSource
            audioSource.clip = fireSound;
        }
        else
        {
            Debug.LogError("��������� ���� �� ��������.");
        }
    }

    // ����� Update ���������� ������ ����
    void Update()
    {
        // ��������, ���� �� ������ ����� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
            // ��������������� �������� ������� ������ ����
            fire.Play();

            // ��������������� ����� ����
            if (audioSource != null && fireSound != null)
            {
                audioSource.Play();
            }
        }
    }
}
