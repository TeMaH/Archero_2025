using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    HealthModel health;

    public HealthModel Health => health ??= GetComponent<HealthModel>();

    private void Awake()
    {
        // Health.InitHealth(95.0f);
    }
}
