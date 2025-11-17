using UnityEngine;
using Assets.Sources.Scripts.Gameplay.Characters.Services.Interfaces;

namespace Assets.Sources.Scripts.Gameplay.Characters.Services.Implementations
{
    public class RigidbodyMover : IMover
    {
        private Rigidbody _movable;

        public RigidbodyMover(Rigidbody movable) =>
            _movable = movable;

        public void Move(Vector3 direction, float speed)
        {
            if (direction.sqrMagnitude.LessThenEpsilon())
                return;

            Vector3 targetVeclocity = direction.normalized * speed;
            targetVeclocity.y = _movable.velocity.y;

            _movable.velocity = targetVeclocity;
        }

        public void Stop()
        {
            Debug.Log("Stop");
            _movable.velocity = Vector3.zero;
        }
    }
}
