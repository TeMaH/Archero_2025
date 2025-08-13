using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    [SerializeField] private float damage = 5.0f;
    private HealthModel _health;

    private void Start()
    {
        _health = GetComponent<HealthModel>();
        
        _health.OnDie += HealthOnOnDie;
        _health.Init(100.0f);
    }

    private void HealthOnOnDie(HealthModel obj)
    {
        Destroy(obj.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        var health = other.gameObject.GetComponent<HealthModel>();
        health.TakeDamage(damage);
        Debug.Log($"Current health : {health.Health}");
    }
}
