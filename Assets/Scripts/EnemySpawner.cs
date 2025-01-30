using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    public GameObject enemyPrefab;// Публичная переменная для хранения префаба врага    
    public Transform[] spawnPoints;// Публичный массив для хранения точек спавна   
    public float spawnInterval = 5f; // Публичная переменная для хранения интервала спавна врагов

    // Метод Start вызывается перед первым кадром
    void Start()
    {
        // Запуск метода SpawnEnemy с интервалом spawnInterval
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    // Метод для спавна врага
    void SpawnEnemy()
    {
        // Проверка, есть ли точки спавна
        if (spawnPoints.Length == 0) return;

        // Выбор случайной точки спавна из массива
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Создание экземпляра врага в выбранной точке спавна
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
