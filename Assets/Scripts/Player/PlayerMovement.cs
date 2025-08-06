using System;
using System.Xml;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Movement movementComponent;
        [SerializeField] private float minMovement;

        private Input_Actions _inputActions;

        private Vector2 _startTouchPos;
        private Vector2 _currentTouchPos;
        private Vector3 _moveDirection;
        public bool IsTouching { get; private set; }

        private void OnEnable()
        {
            SignOnInputSystemActions();
        }

        private void SignOnInputSystemActions()
        {
            _inputActions ??= new Input_Actions();

            _inputActions.Player.Move.performed += OnMovePerformed;

            _inputActions.Enable();
        }

        private void OnMovePerformed(InputAction.CallbackContext ctx)
        {
            var context = ctx.ReadValue<TouchState>();
            if (context.phase == TouchPhase.Ended)
            {
                movementComponent.MoveCharacter(Vector3.zero);
                return;
            }
            
            _startTouchPos = context.startPosition;
            _currentTouchPos = context.position;
            _moveDirection = (_currentTouchPos -_startTouchPos).normalized;
            
            movementComponent.MoveCharacter(_moveDirection);

            if (!(_moveDirection.sqrMagnitude > 0.01f)) return;
            
            var angle = Mathf.Atan2(_moveDirection.x, _moveDirection.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
        }

        private void UnsignFromInputSystemActions()
        {
            if (_inputActions == null) return;

            _inputActions.Player.Move.performed -= OnMovePerformed;

            _inputActions.Disable();
        }

        private void OnDisable()
        {
            UnsignFromInputSystemActions();
        }

        private void OnDestroy()
        {
            UnsignFromInputSystemActions();
        }
    }
}