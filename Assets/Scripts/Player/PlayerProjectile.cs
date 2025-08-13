using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float damage;
    
    private bool _isLaunched = false;
    private Vector3 _moveDirection;

    private int _enemyLayer;
    private HealthModel _healthModel;
    
    private void Start()
    {
        _isLaunched = true;
        _enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    private void Update()
    {
        if (!_isLaunched) return;
        transform.Translate(_moveDirection * (moveSpeed * Time.deltaTime));
    }
    
    public void LaunchProjectile(Vector3 moveDirection)
    {
        _moveDirection = moveDirection;
        _isLaunched = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != _enemyLayer) return;

        _healthModel ??= other.gameObject.GetComponent<HealthModel>();
        _healthModel?.TakeDamage(damage);
        
        Debug.Log(_healthModel?.Health);
        
        gameObject.SetActive(false);
    }
}
