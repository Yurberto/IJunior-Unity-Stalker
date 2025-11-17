using System;
using UnityEngine;

namespace Assets.Sources.Scripts.Gameplay.Characters.Player.Input
{
    public interface IInputService
    {
        public Vector3 MoveDirection { get; }
        public Vector3 MouseDelta { get; }

        public event Action MoveButtonPressed;
        public event Action MoveButtonReleased;

        public event Action MouseDeltaChanged;

        public void Enable();
        public void Disable();
    }
}
