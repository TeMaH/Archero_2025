using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerProjectile projectile;
    [SerializeField] private float cooldownTimer = 0.5f;

    private List<PlayerProjectile> _projectiles;
    private float _defaaultTimerValue;
    private bool _onCooldown;

    private void Awake()
    {
        _projectiles ??= new List<PlayerProjectile>();
        _defaaultTimerValue = cooldownTimer;
    }

    private void Update()
    {
        if (playerMovement.IsMoving) return;
        
        if (!_onCooldown)
        {
            var newProjectile = Instantiate(projectile, transform.localPosition, Quaternion.identity);
            newProjectile?.LaunchProjectile(transform.forward);
            _projectiles.Add(projectile);

            _onCooldown = true;
            return;
        }

        if (_onCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                _onCooldown = false;
                cooldownTimer = _defaaultTimerValue;
            }
        }
        
    }
}