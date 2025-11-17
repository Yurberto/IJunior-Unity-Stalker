using Assets.Sources.Scripts.Gameplay.Characters.Services.Interfaces;
using UnityEngine;

namespace Assets.Sources.Scripts.Gameplay.Characters.Services.Implementations
{
    public class CharacterControllerMover : IMover
    {
        private CharacterController _movable;

        public CharacterControllerMover(CharacterController movable) =>
            _movable = movable;

        public void Move(Vector3 direction, float speed)
        {
            direction.y = 0;
            direction.Normalize();

            _movable.Move(direction * speed);
        }

        public void Stop()
        {
            _movable.Move(Vector3.zero);
        }
    }
}