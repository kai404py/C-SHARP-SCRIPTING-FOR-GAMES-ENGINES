using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Spawn Settings")]
    
    // enemy pramitors
    [SerializeField] private GameObject enemyPrefab; 
    [SerializeField] private int enemyCount = 5; 
    [SerializeField] private int enemyHealth = 100; 
    
    //propity pramitors
    [SerializeField] private float spawnRadius = 10f;
    [SerializeField] private Vector2 spawnCenter = Vector2.zero; 
    
    
    
    [Header("Delete Settings")]
    [SerializeField] private string tagToDelete = "Barrier";
    
    private int aliveEnemyCount;
    private int[] aliveEnemyIds;
    private int[] deadEnemyIds;

    
    //Spawns the enemys on start game
    void Start()
    {
        aliveEnemyIds = new int[enemyCount];
        deadEnemyIds = new int[enemyCount];
        
        for (int i = 0; i < deadEnemyIds.Length; i++)
        {
            deadEnemyIds[i] = -1;
        }
        
        SpawnEnemies();
    }
    
    /// <summary>
    /// When called it will spawn the enemys at a random location within the propity pramitors
    /// It will also give each enemy a unique ID and add that ID to the aliveEnemyIds array 
    /// </summary>
    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 randomPos = Random.insideUnitCircle * spawnRadius;
            Vector2 spawnPos = spawnCenter + randomPos;
            
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            
            SimpleEnermy enemyScript = enemy.GetComponent<SimpleEnermy>();
            enemyScript.SetHealth(enemyHealth);
            enemyScript.EnemyID = i;
            aliveEnemyIds[i] = i;
            
            if (!enemy.CompareTag("Enemy"))
            {
                enemy.tag = "Enemy";
            }
        }
        
        aliveEnemyCount = enemyCount;
    }

    // When the enemy dies updates the dead enemys array and if all enimies are dead removes the barriers to allow the player to the next level
    public void EnemyDied(int ID)
    {
        bool alreadyDead = false;
        for (int i = 0; i < deadEnemyIds.Length; i++)
        {
            if (deadEnemyIds[i] == ID)
            {
                alreadyDead = true;
                break;
            }
        }
        
        if (!alreadyDead)
        {
            for (int i = 0; i < deadEnemyIds.Length; i++)
            {
                if (deadEnemyIds[i] == -1)
                {
                    deadEnemyIds[i] = ID;
                    break;
                }
            }
        
            aliveEnemyCount--;
        }
        
        if (aliveEnemyCount <= 0)
        {
            GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag(tagToDelete);
            foreach (GameObject obj in objectsToDelete)
            {
                Destroy(obj);
            }
        }
    }
}