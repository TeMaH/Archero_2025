using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    private HealthModel _health;

    private void Start()
    {
        _health = GetComponent<HealthModel>();
        
        _health.OnDie += HealthOnOnDie;
        _health.InitHealth(100.0f);
    }

    private void HealthOnOnDie(HealthModel obj)
    {
        Debug.Log($"{gameObject.name} is Dead !");
        Destroy(obj.gameObject);
    }
}
