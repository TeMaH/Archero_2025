using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] List<LevelSpawn> levelsPrefabs;
    public LevelSpawn CurrentLevel => currentLevel;

    LevelSpawn currentLevel;

    public void SpawnLevel()
    {
        if (levelsPrefabs == null || levelsPrefabs.Count == 0)
        {
            return;
        }
        var prefabOfLevel = levelsPrefabs[Random.Range(0, levelsPrefabs.Count)];
        currentLevel = Instantiate(prefabOfLevel, Vector3.zero, Quaternion.identity);
        currentLevel.Gate.SwitchState(false);
    }
}
