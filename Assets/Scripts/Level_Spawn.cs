using UnityEngine;

public class LevelSpawn : MonoBehaviour
{
    [SerializeField] Gate gate;
    public Gate Gate => gate;

    public Transform playerSpawnPoint;
    public Transform[] enemySpawnPoint;
    
    public void SpawnEnemy(GameObject enemyPrefab)
    {
        foreach (var spawnPoint in enemySpawnPoint)
        {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
