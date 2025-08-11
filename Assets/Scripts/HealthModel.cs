using System;
using UnityEngine;

public class HealthModel : MonoBehaviour
{
    public event Action<HealthModel> OnSpawn;
    public event Action<HealthModel> OnDie;
    
    private float _health;
    public float Health => _health;
    
    private float _maxHealth;
    public float MaxHealth => _maxHealth;

    public void InitHealth(float value)
    {
        _health = value;
    }

    public void TakeDamage(float damageAmount)
    {
        _health -= damageAmount;
        _health = Mathf.Clamp(_health, 0f, _maxHealth);
        
        if (_health > 0.0f) return;
        
        Die();
    }

    public void Heal(float healAmount)
    {
        _health += healAmount;
        _health = Mathf.Clamp(_health, 0f, _maxHealth);
    }

    public virtual void Die()
    {
        OnDie?.Invoke(this);
    }

    public virtual void Respawn(float initHealthAmount)
    {
        OnSpawn?.Invoke(this);
    }
}
