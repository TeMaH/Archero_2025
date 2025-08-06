using UnityEngine;

public class LevelSpawn : MonoBehaviour
{
    public Transform playerSpawnPoint;
    public Transform[] enemySpawnPoint;

    public void SpawnPlayer(GameObject playerPrefab)
    {
        GameObject player = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
    }
    
    public void SpawnEnemy(GameObject enemyPrefab)
    {
        foreach (var spawnPoint in enemySpawnPoint)
        {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
