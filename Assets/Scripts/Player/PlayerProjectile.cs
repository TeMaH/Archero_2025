using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    private bool _isLaunched = false;
    private Vector3 _moveDirection;

    private void Start()
    {
        _isLaunched = true;
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
        // pool
        gameObject.SetActive(false);
    }
}
