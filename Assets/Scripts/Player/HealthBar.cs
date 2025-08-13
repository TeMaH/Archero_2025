using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Canvas healthBarCanvas;
    [SerializeField] private Camera mainCamera;

    // replace with PlayerModel !
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private Slider healthBar;

    private void Start()
    {
        healthBar.value = playerAttack.HealthModel.Health;
        healthBar.maxValue = playerAttack.HealthModel.MaxHealth;
        
        playerAttack.HealthModel.OnTakeDamage += OnPlayerTakeDamage;
    }

    private void OnPlayerTakeDamage(HealthModel ctx)
    {
        healthBar.value = ctx.Health / ctx.MaxHealth;
    }

    private void LateUpdate()
    {
        transform.LookAt(healthBarCanvas.transform.position + mainCamera.transform.forward);
    }
}
