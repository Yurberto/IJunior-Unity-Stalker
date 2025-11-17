using UnityEngine;

namespace Assets.Sources.Scripts.Gameplay.Characters.Services.Interfaces
{
    public interface IRotator
    {
        public void Rotate(Vector3 direction, float speed);
    }
}
