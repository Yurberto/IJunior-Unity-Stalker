using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Sources.Scripts.Gameplay.Characters.Player.Input
{
    public class InputService : IInputService
    {
        private PlayerInput _playerInput;

        public Vector3 MoveDirection { get; private set; }
        public Vector3 MouseDelta { get; private set; }

        public event Action MoveButtonPressed;
        public event Action MoveButtonReleased;

        public event Action MouseDeltaChanged;

        public InputService(PlayerInput playerInput) =>
            _playerInput = playerInput;

        public void Enable()
        {
            _playerInput.Enable();

            _playerInput.Player.Move.performed += OnMove;
            _playerInput.Player.Move.canceled += OnStopMove;

            _playerInput.Player.Look.performed += OnLook;
        }

        public void Disable()
        {
            _playerInput.Disable();

            _playerInput.Player.Move.performed -= OnMove;
            _playerInput.Player.Move.canceled -= OnStopMove;

            _playerInput.Player.Look.performed -= OnLook;
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            Vector2 inputMove = context.ReadValue<Vector2>();

            MoveDirection = new Vector3(inputMove.x, 0.0f, inputMove.y);
            MoveButtonPressed?.Invoke();
        }

        private void OnStopMove(InputAction.CallbackContext context)
        {
            MoveDirection = Vector3.zero;
            MoveButtonReleased?.Invoke();
        }

        private void OnLook(InputAction.CallbackContext context)
        {
            MouseDelta = context.ReadValue<Vector2>();
            MouseDeltaChanged?.Invoke();
        }
    }
}
