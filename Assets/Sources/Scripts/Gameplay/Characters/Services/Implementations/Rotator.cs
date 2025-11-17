using UnityEngine;
using Assets.Sources.Scripts.Gameplay.Characters.Services.Interfaces;

namespace Assets.Sources.Scripts.Gameplay.Characters.Services.Implementations
{
    public class Rotator : IRotator
    {
        private Transform _rotatable;

        public Rotator(Transform rotatable) =>
            _rotatable = rotatable;

        public void Rotate(Vector3 direction, float speed)
        {
            direction.y = 0;
            direction.Normalize();

            RotateToDirection(direction, speed);
        }

        private void RotateToDirection(Vector3 direction, float speed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            _rotatable.rotation = Quaternion.Slerp(_rotatable.rotation, targetRotation, speed);
        }
    }
}
