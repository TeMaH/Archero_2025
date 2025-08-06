using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotationSpeed;

        private CharacterController _controller;
        
        private Vector3 _currentDirection;

        private void Awake()
        {
            _controller = TryGetComponent<CharacterController>(out var controller) 
                ? controller : gameObject.AddComponent<CharacterController>();
            
            _currentDirection = Vector3.zero;
        }

        public void MoveCharacter(Vector3 direction)
        {
            _currentDirection = new Vector3(direction.x, -15.0f, direction.y);
        }

        private void Update()
        {
            if (_currentDirection == Vector3.zero) return;
            
            _controller.Move(_currentDirection * (moveSpeed * Time.deltaTime));
        }
    }
}