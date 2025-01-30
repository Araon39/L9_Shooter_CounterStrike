using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimation : MonoBehaviour
{
    // Публичная переменная для хранения ссылки на систему частиц огня
    public ParticleSystem fire;

    // Публичная переменная для хранения ссылки на аудиоклип огня
    public AudioClip fireSound;

    // Приватная переменная для хранения ссылки на AudioSource
    private AudioSource audioSource;

    // Метод Start вызывается перед первым кадром
    void Start()
    {
        // Получение компонента AudioSource на игровом объекте
        audioSource = GetComponent<AudioSource>();

        // Проверка, назначен ли аудиоклип
        if (fireSound != null)
        {
            // Назначение аудиоклипа AudioSource
            audioSource.clip = fireSound;
        }
        else
        {
            Debug.LogError("Аудиоклип огня не назначен.");
        }
    }

    // Метод Update вызывается каждый кадр
    void Update()
    {
        // Проверка, была ли нажата левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Воспроизведение анимации системы частиц огня
            fire.Play();

            // Воспроизведение звука огня
            if (audioSource != null && fireSound != null)
            {
                audioSource.Play();
            }
        }
    }
}
