using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthModel health;
    [SerializeField] private Canvas healthBarCanvas;
    [SerializeField] private Slider healthBar;

    private Camera _mainCamera;

    private void Start()
    {
        healthBar.value = health.Health;
        healthBar.maxValue = health.MaxHealth;
        
        health.OnTakeDamage += OnPlayerTakeDamage;
        
        _mainCamera = Camera.main;
    }

    private void OnPlayerTakeDamage(HealthModel ctx)
    {
        healthBar.value = (health.Health / health.MaxHealth) * 100.0f;
        Debug.Log($"Current Health: {health.Health} / MaxHealth: {health.MaxHealth} = healthBar.value");
    }

    private void LateUpdate()
    {
        // transform.LookAt(transform.position = _mainCamera.transform.forward);
    }
}
