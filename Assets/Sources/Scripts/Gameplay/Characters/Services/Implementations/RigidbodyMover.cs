using UnityEngine;
using Assets.Sources.Scripts.Gameplay.Characters.Services.Interfaces;

namespace Assets.Sources.Scripts.Gameplay.Characters.Services.Implementations
{
    public class RigidbodyMover : IMover
    {
        private Rigidbody _movable;

        public void Move(Vector3 direction, float speed)
        {
            direction.y = 0;
            direction.Normalize();

            ChangeSpeed(direction * speed);
        }

        public void Stop()
        {
            _movable.velocity = new Vector3(0.0f, _movable.velocity.y, 0.0f);
        }

        private void ChangeSpeed(Vector3 speed)
        {
            _movable.velocity = new Vector3(speed.x, _movable.velocity.y, speed.z);
        }
    }
}
