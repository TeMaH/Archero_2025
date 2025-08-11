using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject levelPrefab;

    void Start()
    {
        if (levelPrefab != null)
        {
            Instantiate(levelPrefab, Vector3.zero, Quaternion.identity);
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
