using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerProjectile projectile;
    
    [SerializeField] private float cooldownTimer = 0.5f;

    [SerializeField] private float overlappingRange;
    [SerializeField] private LayerMask ableToAttackLayer;

    private List<PlayerProjectile> _projectiles;
    private Vector3 _attackDirection;
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
            var enemy = FindClosestEnemy();

            if (!enemy)
            {
                return;
            }
            else
            {
                transform.LookAt(enemy);
                _attackDirection = (enemy.position - transform.position).normalized;
            }
            
            var newProjectile = Instantiate(projectile, transform.localPosition, Quaternion.identity);
            _projectiles.Add(projectile);
            
            newProjectile?.LaunchProjectile(_attackDirection);

            _onCooldown = true;
            return;
        }

        CountTimer();
    }

    private void CountTimer()
    {
        if (!_onCooldown) return;
        
        cooldownTimer -= Time.deltaTime;
        if (!(cooldownTimer <= 0f)) return;
        
        _onCooldown = false;
        cooldownTimer = _defaaultTimerValue;
    }

    public Transform FindClosestEnemy()
    {
        var enemies = Physics.OverlapSphere(transform.position, overlappingRange, ableToAttackLayer);

        Transform closestEnemy = null;
        var closestDistanceSqr = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            var sqrDistance = (enemy.transform.position - transform.position).sqrMagnitude;
            if (sqrDistance < closestDistanceSqr)
            {
                closestDistanceSqr = sqrDistance;
                closestEnemy = enemy.transform;
            }
        }

        return closestEnemy;
    }
}