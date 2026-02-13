using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject enemyPrefab; 
    [SerializeField] private int enemyCount = 5; 
    [SerializeField] private int enemyHealth = 100; 
    [SerializeField] private float spawnRadius = 10f;
    [SerializeField] private Vector2 spawnCenter = Vector2.zero; 
    
    [Header("Delete Settings")]
    [SerializeField] private string tagToDelete = "Barrier";
    
    private int aliveEnemyCount;

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 randomPos = Random.insideUnitCircle * spawnRadius;
            Vector2 spawnPos = spawnCenter + randomPos;
            
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            
            SimpleEnermy enemyScript = enemy.GetComponent<SimpleEnermy>();
            enemyScript.SetHealth(enemyHealth);
            
            if (!enemy.CompareTag("Enemy"))
            {
                enemy.tag = "Enemy";
            }
        }
        
        aliveEnemyCount = enemyCount;
        Debug.Log("Spawned " + enemyCount + " enemies");
    }

    public void EnemyDied()
    {
        aliveEnemyCount--;
        Debug.Log("Enemies remaining: " + aliveEnemyCount);
        
        if (aliveEnemyCount <= 0)
        {
            Debug.Log("All enemies dead! Deleting object.");
            GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag(tagToDelete);
            foreach (GameObject obj in objectsToDelete)
            {
                Destroy(obj);
            }
        }
    }
}