using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    public GameObject enemyPrefab;// ��������� ���������� ��� �������� ������� �����    
    public Transform[] spawnPoints;// ��������� ������ ��� �������� ����� ������   
    public float spawnInterval = 5f; // ��������� ���������� ��� �������� ��������� ������ ������

    // ����� Start ���������� ����� ������ ������
    void Start()
    {
        // ������ ������ SpawnEnemy � ���������� spawnInterval
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    // ����� ��� ������ �����
    void SpawnEnemy()
    {
        // ��������, ���� �� ����� ������
        if (spawnPoints.Length == 0) return;

        // ����� ��������� ����� ������ �� �������
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // �������� ���������� ����� � ��������� ����� ������
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
