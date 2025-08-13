using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] PlayerModel playerPrefab;

    public PlayerModel CurrentPlayer => currentPlayer;
    PlayerModel currentPlayer;

    private void Start()
    {
        StartGame();    
    }

    public void StartGame() 
    {
        PrepareLevel();
        SpawnPlayer();
        StartCoroutine(OpenGateWithDelay(2.0f));
    }

    public void EndGame()
    {
        if (currentPlayer != null)
        {
            currentPlayer.Health.OnDie -= Player_OnDie;
        }
        var level = LevelManager.Instance.CurrentLevel;
        if (level != null)
        {
            level.Gate.OnPlayerEnteredEvent -= Gate_OnPlayerEntered;
        }
        SceneManager.LoadScene("MainMenu");
    }

    void PrepareLevel()
    {
        LevelManager.Instance.SpawnLevel();
    }

    void SpawnPlayer()
    {
        var level = LevelManager.Instance.CurrentLevel;
        if (level == null)
        {
            Debug.LogError("CurrentLevel id NULL");
        }
        currentPlayer = Instantiate(playerPrefab, level.playerSpawnPoint.position, level.playerSpawnPoint.rotation);
        Assert.IsNotNull(currentPlayer);
        currentPlayer.Health.OnDie += Player_OnDie;
    }

    private void Player_OnDie(HealthModel playerHealth)
    {
        EndGame();
    }

    IEnumerator OpenGateWithDelay(float delay)
    { 
        yield return new WaitForSeconds(delay);
        LevelManager.Instance.CurrentLevel.Gate.OnPlayerEnteredEvent += Gate_OnPlayerEntered;
        LevelManager.Instance.CurrentLevel.Gate.SwitchState(true);
    }

    private void Gate_OnPlayerEntered(PlayerModel player)
    {
        LevelManager.Instance.CurrentLevel.Gate.OnPlayerEnteredEvent -= Gate_OnPlayerEntered;
        EndGame();
    }
}