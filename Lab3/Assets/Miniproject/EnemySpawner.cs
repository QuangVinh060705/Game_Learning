using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Random vị trí quanh màn hình (đơn giản hóa)
        Vector2 randomPos = Random.insideUnitCircle.normalized * 8f; 
        Instantiate(enemyPrefab, randomPos, Quaternion.identity);
    }
}